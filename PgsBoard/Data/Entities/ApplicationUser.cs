using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PgsBoard.AuthInfrastructure;

namespace PgsBoard.Data.Entities
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public ICollection<Board> Boards { get; set; }
        
        public async Task<ClaimsIdentity> GenerateIdentityAsync(ApplicationUserManager manager, string authType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authType);
            return userIdentity;
        }
    }
}