using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Data.Entity;

namespace SocialNetwork.Infrastructure
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();
            Bind<IMessageRepository>().To<MessageRepository>().InRequestScope();
            Bind<IPhotoRepository>().To<PhotoRepository>().InRequestScope();
            Bind<IUserService>().To<UserService>().InRequestScope();
            Bind<IRoleService>().To<RoleService>().InRequestScope();
            Bind<IMessageService>().To<MessageService>().InRequestScope();
            Bind<IPhotoService>().To<PhotoService>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<DbContext>().To<SocialNetworkEntities>().InRequestScope();

        }
    }
}