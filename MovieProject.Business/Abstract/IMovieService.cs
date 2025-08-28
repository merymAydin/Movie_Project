using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Abstract
{
    public interface IMovieService : IGenericService<Movie>
    {
        List<Movie> GetByName(string name);
        List<Movie> GetByLessThanIMDB(decimal imdb);
        List<Movie> GetByGreaterThanIMDB(decimal imdb);
        List<Movie> GetByCategoryId(Guid categoryId);
        List<Movie> GetByDirectorId(Guid  directorId);
        List<Movie> GetByMoviesWithFullInfo(Guid actorId);
    }
}
