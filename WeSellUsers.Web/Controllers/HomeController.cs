using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeSellUsers.Data.Services;

namespace WeSellUsers.Web.Controllers
{
  public class HomeController : Controller
  {
    IUserRepository db;

    public HomeController(IUserRepository db)
    {
      this.db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      return View();
    }

    public ActionResult Contact()
    {
      return View();
    }
  }
}