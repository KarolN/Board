using System.Web;
using Microsoft.AspNet.Identity;

namespace PgsBoard.Infrastructure
{
    public class AuthInfrastructure : IAuthInfrastructure
    {
        public string GetCurrentUserId()
        {
            var context = HttpContext.Current.GetOwinContext();
            var user = context.Authentication.User;
            return user == null ? null : user.Identity.GetUserId();
        }
    }
}