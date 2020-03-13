using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSellUsers.Data.Models;

namespace WeSellUsers.Data.Services
{
  public interface IUserRepository
  {
    IEnumerable<User> GetAll();

    Task<List<User>> GetUsersAsync();

    User Get(int id);

    void Add(User user);

    void Update(User user);

    void Delete(int id);
  }
}
