using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PgsBoard.Data.Entities;

namespace PgsBoard.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Board> Boards { get; set; }

        public DbSet<List> Lists { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DatabaseContext() : base("defaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}