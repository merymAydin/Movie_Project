
using MovieProject.Business.Abstract;
using MovieProject.Business.Concrete;
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

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MovieDbContext>();
            builder.Services.AddScoped<ICategoryService,CategoryManager>();
            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            

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
