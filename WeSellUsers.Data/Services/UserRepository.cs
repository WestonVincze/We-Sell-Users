using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSellUsers.Data.Models;

namespace WeSellUsers.Data.Services
{
  public class UserRepository : IUserRepository
  {
    private readonly WeSellUsersDbContext _context;

    public UserRepository(WeSellUsersDbContext context)
    {
      this._context = context;
    }

    // get all users
    public async Task<List<User>> GetUsersAsync()
    {
      return await _context.Users.ToListAsync();
    }

    // add user
    public void Add(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    // get user by id
    public User Get(int id)
    {
      return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    // get all users
    public IEnumerable<User> GetAll()
    {
      return from u in _context.Users
             orderby u.FirstName
             select u;
    }

    // update existing user
    public void Update(User user)
    {
      var entry = _context.Entry(user);
      entry.State = EntityState.Modified;
      _context.SaveChanges();
    }

    // delete user
    public void Delete(int id)
    {
      var entry = _context.Entry(_context.Users.Find(id));
      entry.State = EntityState.Deleted;
      _context.SaveChanges();
    }
  }
}
