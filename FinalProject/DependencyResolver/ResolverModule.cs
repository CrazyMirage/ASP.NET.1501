using BLL.Interfacies.Services;
using BLL.Services;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfacies;
using DAL;

namespace DependencyResolver
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<DalUser>>().To<UserRepository>().InRequestScope();
            Bind<IRepository<DalRole>>().To<RoleRepository>().InRequestScope(); ;

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope(); ;

            Bind<IAccountService>().To<AccountService>().InRequestScope(); ;

            Bind<DbContext>().To<GalleryModel>().InRequestScope();

            //Unbind<ModelValidatorProvider>();

            //Bind<DbContext>().To<EntityModel>().InSingletonScope(); ///bad way. we coudn't make dispose 
            //Bind<IUserRepository>().To<UserRepository>();
            //Bind<IUnitOfWork>().To<UnitOfWork>();
            //Bind<IUserService>().To<UserService>();
        }
    }
}
