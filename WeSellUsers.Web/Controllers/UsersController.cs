using System.Threading.Tasks;
using System.Web.Mvc;
using WeSellUsers.Data.Models;
using WeSellUsers.Data.Services;

namespace WeSellUsers.Web.Controllers
{
  public class UsersController : Controller
  {
    private readonly IUserRepository userRepository;
    public UsersController()
    {
      userRepository = new UserRepository(new WeSellUsersDbContext());
    }

    /// <summary>
    /// Asynchronously retrieves list of users or Users' index page.
    /// This is the only Async function, just a small taste.
    /// </summary>
    /// <returns>View with list of users</returns>
    public async Task<ActionResult> Index()
    {
      return View(await userRepository.GetUsersAsync());
    }

    /// <summary>
    /// Accepts a user with the necrssary props (does not need id) and attempts to add it to database.
    /// </summary>
    /// <param name="user">first name, last name, email</param>
    /// <returns>Json result with message to indicate success or failure</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include="FirstName,LastName,Email")] User user)
    {
      string err = "";
      if (string.IsNullOrEmpty(user.FirstName) 
          && string.IsNullOrEmpty(user.LastName)
          && string.IsNullOrEmpty(user.Email))
      {
        err = "At least one value must be entered";
        ModelState.AddModelError(string.Empty, err);
      }
      else if (!IsValidEmail(user.Email))
      {
        if (!string.IsNullOrEmpty(user.Email))
        {
          err = "Invalid email address.";
          ModelState.AddModelError(string.Empty, err);
        }
      }

      if (ModelState.IsValid)
      {
        userRepository.Add(user);
        return Json(new { success = true, user});
      }
      return Json(new { success = false, err });
    }

    /// <summary>
    /// Accepts a user with all props and attempts to update an existing user with new data
    /// </summary>
    /// <param name="user">id, first name, last name, email</param>
    /// <returns>Json result with message to indicate success or failure</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(User user)
    {
      var err = "";
      if (string.IsNullOrEmpty(user.FirstName)
          && string.IsNullOrEmpty(user.LastName)
          && string.IsNullOrEmpty(user.Email))
      {
        err = "At least one value must be entered";
        ModelState.AddModelError(string.Empty, err);
      }
      else if (!IsValidEmail(user.Email))
      {
        if (!string.IsNullOrEmpty(user.Email))
        {
          err = "Invalid email address.";
          ModelState.AddModelError(string.Empty, err);
        }
      }

      if (ModelState.IsValid)
      {
        userRepository.Update(user);
        return Json(new { success = true, user });
      }
      return Json(new { success = false, user, err });
    }

    /// <summary>
    /// Removes user from database if user with matching id is found
    /// </summary>
    /// <param name="id">id of user to be deleted</param>
    /// <returns>Json result with message to indicate success or failure</returns>
    [HttpGet]
    public ActionResult Delete(int id)
    {
      var model = userRepository.Get(id);
      if (model == null)
      {
        return Json(new { success = false, id });
      }
      userRepository.Delete(id);
      return Json(new { success = true, id }, JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Attempts to create a MailAddress object to check if email is legitimate.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsValidEmail(string email)
    {
      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        return false;
      }
    }
  }
}