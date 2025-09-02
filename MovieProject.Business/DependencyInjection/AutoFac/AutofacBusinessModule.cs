using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Business.Security.Jwt;
using Core.Business.Utilities.Security.Jwt;
using MovieProject.Business.Abstract;
using MovieProject.Business.Concrete;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.DataAccess.Repositories.Concrete.EntityFramework;

namespace MovieProject.Business.DependencyInjection.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieManager>().As<IMovieService>();
            builder.RegisterType<EfMovieRepository>().As<IMovieRepository>();
            builder.RegisterType<DirectorManager>().As<IDirectorService>();
            builder.RegisterType<EfDirectorRepository>().As<IDirectorRepository>();
            builder.RegisterType<ActorManager>().As<IActorService>();
            builder.RegisterType<EfActorRepository>().As<IActorRepository>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
