using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;
using MovieProject.Business.Abstract;
using MovieProject.Business.Concrete;
using MovieProject.Business.Mappers.Categories;
using MovieProject.Business.Mappers.Profiles;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.DataAccess.Repositories.Concrete.EntityFramework;

namespace MovieProject.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            builder.Services.AddDbContext<MovieDbContext>();
            builder.Services.AddScoped<ICategoryService,CategoryManager>();
            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            builder.Services.AddScoped<IMovieService, MovieManager>();
            builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
            builder.Services.AddScoped<IDirectorService, DirectorManager>();
            builder.Services.AddScoped<IDirectorRepository, EfDirectorRepository>();
            builder.Services.AddScoped<IActorService, ActorManager>();
            builder.Services.AddScoped<IActorRepository, EfActorRepository>();
            builder.Services.AddScoped<ICategoryMapper, AutoCategoryMapper>();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
