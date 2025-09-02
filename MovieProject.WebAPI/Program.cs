using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Business.Security.Jwt;
using Core.Business.Security.Jwt.Encyriptions;
using Core.DataAccess;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MovieProject.Business.Abstract;
using MovieProject.Business.Concrete;
using MovieProject.Business.DependencyInjection.AutoFac;
using MovieProject.Business.Mappers.Categories;
using MovieProject.Business.Mappers.Profiles;
using MovieProject.Business.Validators;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.DataAccess.Repositories.Concrete.EntityFramework;
using MovieProject.Entities.Entities;

namespace MovieProject.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.WithOrigins("http://localhost:5173/")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MovieDbContext>();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });
            builder.Services.AddScoped<ICategoryMapper, AutoCategoryMapper>();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();


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
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
