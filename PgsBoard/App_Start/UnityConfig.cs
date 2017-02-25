using System;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Web;
using AutoMapper;
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
using PgsBoard.Repositories;

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
            RegisterRepositories(container);
            RegisterAuthInfrastructure(container);
            RegisterServices(container);
            RegisterInfrastructure(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IBoardsService, BoardsService>();
            container.RegisterType<IListsService, ListsService>();
            container.RegisterType<ICartsService, CartsService>();
        }

        private static void RegisterDBContext(IUnityContainer container)
        {
            container.RegisterType<DbContext, DatabaseContext>(new PerRequestLifetimeManager());
        }

        private static void RegisterAuthInfrastructure(IUnityContainer container)
        {
            container.RegisterType<UserManager<ApplicationUser, string>, ApplicationUserManager>();
            container.RegisterType<IUserStore<ApplicationUser, string>, ApplicationUserStore>();
            container.RegisterType<SignInManager<ApplicationUser, string>, ApplicationSignInManager>();
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IMapper>(new InjectionFactory(c => AutoMapperConfigurartion.CreateMapper()));
        }

        private static void RegisterInfrastructure(IUnityContainer container)
        {
            container.RegisterType<IAuthInfrastructure, Infrastructure.AuthInfrastructure>();
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IBoardsRepository, BoardsRepository>();
            container.RegisterType<IListsRepository, ListsRepository>();
            container.RegisterType<ICartsRepository, CartsRepository>();
        }
    }
}
