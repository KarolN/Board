using System;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PgsBoard.AuthInfrastructure;
using PgsBoard.Data;
using PgsBoard.Data.Entities;
using PgsBoard.Services;
using PgsBoard.Services.Implementation;
using Microsoft.Owin.Host.SystemWeb;
using PgsBoard.Infrastructure;

namespace PgsBoard
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            RegisterDBContext(container);
            RegisterAuthInfrastructure(container);
            RegisterServices(container);
            RegisterInfrastructure(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IAuthService, AuthService>();
        }

        private static void RegisterDBContext(IUnityContainer container)
        {
            container.RegisterType<DbContext, DatabaseContext>();
        }

        private static void RegisterAuthInfrastructure(IUnityContainer container)
        {
            container.RegisterType<UserManager<ApplicationUser, string>, ApplicationUserManager>();
            container.RegisterType<IUserStore<ApplicationUser, string>, ApplicationUserStore>();
            container.RegisterType<SignInManager<ApplicationUser, string>, ApplicationSignInManager>();
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
        }

        private static void RegisterInfrastructure(IUnityContainer container)
        {
            container.RegisterType<IAuthInfrastructure, Infrastructure.AuthInfrastructure>();
        }
    }
}
