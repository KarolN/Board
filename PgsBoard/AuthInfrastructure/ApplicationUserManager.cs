using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PgsBoard.Data.Entities;

namespace PgsBoard.AuthInfrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, string> store) : base(store)
        {

        }
    }
}