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
            Bind<IRepository<DalRole>>().To<RoleRepository>().InRequestScope();

            Bind<IPhotoRepository>().To<PhotoRepository>().InRequestScope();
            Bind<IRepository<DalLike>>().To<LikeRepository>().InRequestScope();
            Bind<IRepository<DalComment>>().To<CommentRepository>().InRequestScope();

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            Bind<IAccountService>().To<AccountService>();
            Bind<IPhotoService>().To<PhotoService>();
            Bind<IPhotoLikeService>().To<LikeService>();
            Bind<IPhotoCommentService>().To<WCFCommentServiceAdapter>();

            Bind<DbContext>().To<GalleryModel>().InRequestScope();



        }
    }
}
