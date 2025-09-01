using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.Business.Utilities.Results;
using MovieProject.Entities.Dtos.Movies;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Abstract
{
    public interface IMovieService : IGenericService<Movie, MovieResponseDto, MovieAddRequestDto, MovieUpdateRequestDto>, IGenericServiceAsync<Movie, MovieResponseDto, MovieAddRequestDto, MovieUpdateRequestDto> 
    {
        //List<Movie> GetByName(string name);
        //List<Movie> GetByLessThanIMDB(decimal imdb);
        //List<Movie> GetByGreaterThanIMDB(decimal imdb);
        //List<Movie> GetByCategoryId(Guid categoryId);
        //List<Movie> GetByDirectorId(Guid  directorId);
        IDataResult<List<MovieDetailDto>> GetMoviesWithFullInfo();
    }
}
