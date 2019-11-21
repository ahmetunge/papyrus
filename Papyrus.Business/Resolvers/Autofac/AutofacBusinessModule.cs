using Autofac;
using Core.Utilities.Security;
using Core.Utilities.Security.JWT;
using Papyrus.Business.Abstract;
using Papyrus.Business.Concrete;
using Papyrus.DataAccess.Abstract;
using Papyrus.DataAccess.Concrete.EntityFramework;

namespace Papyrus.Business.Resolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<EfCoreBookRepository>().As<IBookRepository>();

            builder.RegisterType<EfCoreUserRepository>().As<IUserRepository>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtTokenHelper>().As<ITokenHelper>();

            builder.RegisterType<EfCoreUnitOfWork>().As<IUnitOfWork>();
        }
    }
}