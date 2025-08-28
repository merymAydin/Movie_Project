using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Entities;

namespace MovieProject.DataAccess.Repositories.Concrete.EntityFramework
{
    public sealed class EfMovieRepository : EfGenericRepository<Movie, MovieDbContext>, IMovieRepository
    {
        public EfMovieRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
