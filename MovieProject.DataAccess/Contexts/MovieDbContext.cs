using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CoreEntity.Concrete;
using Microsoft.EntityFrameworkCore;
using MovieProject.Entities.Entities;
using User = MovieProject.Entities.Entities.User;

namespace MovieProject.DataAccess.Contexts
{
    public sealed class MovieDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HLA9L30F\SQLEXPRESS;Initial Catalog=MovieDb;Integrated Security=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Movie model configuration 
            modelBuilder.Entity<Movie>().Property(m => m.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Description).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Movie>().Property(p => p.IMDB).HasPrecision(4, 2);
            modelBuilder.Entity<Movie>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Movie>().HasKey(p => p.Id);
            modelBuilder.Entity<Movie>().HasOne(p => p.Category).WithMany(c => c.Movies).HasForeignKey(p => p.CategoryId);


            //Category model configuration
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(250);

            //Director model configuration
            modelBuilder.Entity<Director>().Property(d => d.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Director>().Property(d => d.LastName).HasMaxLength(50).IsRequired();
            base.OnModelCreating(modelBuilder);

            var categoryId = Guid.Parse("BDAFA56B-368B-4633-ADB2-963AA41D0809");
            var directorId = Guid.Parse("6E00E3AA-2AA2-4BAD-AE37-25C16D34ACC1");

            //Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = categoryId, Name = "Action" },
                new Category { Id = Guid.NewGuid(), Name = "Comedy" },
                new Category { Id = Guid.NewGuid(), Name = "Sci-fi" },
                new Category { Id = Guid.NewGuid(), Name = "Fantasy" },
                new Category { Id = Guid.NewGuid(), Name = "Documentary" },
                new Category { Id = Guid.NewGuid(), Name = "Horror" }
             );

            //Seed Data for Directors
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = directorId, FirstName = "Christopher", LastName = "Nolan", BirthDate = new DateTime(1970, 7, 30), Description = "British-American film director, producer, and screenwriter." },
                new Director { Id = Guid.NewGuid(), FirstName = "Steven", LastName = "Spielberg", BirthDate = new DateTime(1946, 12, 18), Description = "American film director, producer, and screenwriter." },
                new Director { Id = Guid.NewGuid(), FirstName = "Martin", LastName = "Scorsese", BirthDate = new DateTime(1942, 11, 17), Description = "American film director, producer, screenwriter, and actor." },
                new Director { Id = Guid.NewGuid(), FirstName = "Quentin", LastName = "Tarantino", BirthDate = new DateTime(1963, 3, 27), Description = "American filmmaker, actor, and screenwriter." },
                new Director { Id = Guid.NewGuid(), FirstName = "James", LastName = "Cameron", BirthDate = new DateTime(1954, 8, 16), Description = "Canadian filmmaker and environmental advocate." });



            //Seed data for movies
            modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = Guid.NewGuid(), Name = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", IMDB = 8.8m, PublishDate = new DateTime(2010, 7, 16), CategoryId = categoryId, DirectorId = directorId },
             new Movie { Id = Guid.NewGuid(), Name = "The Dark Knight", Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", IMDB = 9.0m, PublishDate = new DateTime(2008, 7, 18), CategoryId = categoryId, DirectorId = directorId },
             new Movie { Id = Guid.NewGuid(), Name = "Interstellar", Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", IMDB = 8.6m, PublishDate = new DateTime(2014, 11, 7), CategoryId = categoryId, DirectorId = directorId });
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
