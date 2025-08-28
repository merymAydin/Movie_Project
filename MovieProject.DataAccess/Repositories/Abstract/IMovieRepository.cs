using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using MovieProject.Entities.Entities;

namespace MovieProject.DataAccess.Repositories.Abstract
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
    }
}
