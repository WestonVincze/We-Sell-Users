using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSellUsers.Data.Models;

namespace WeSellUsers.Data.Services
{
  public class WeSellUsersDbContext : DbContext
  {
    public WeSellUsersDbContext() : base("WeSellUsers")
    {
      Database.SetInitializer(new WeSellUsersDbInitializer());
    }
    public DbSet<User> Users { get; set; }

  }
}
