using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PgsBoard.Data.Entities;

namespace PgsBoard.AuthInfrastructure
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(DbContext ctx) : base(ctx)
        {
        }
    }
}