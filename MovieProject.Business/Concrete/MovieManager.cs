using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Business;
using Core.Business.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieProject.Business.Abstract;
using MovieProject.Business.Constants;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Movies;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class MovieManager : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieManager(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public IDataResult<ICollection<MovieResponseDto>> GetAll(bool deleted = false)
        {
            try
            {
                var movies = _movieRepository.GetAll(m => m.IsDeleted == false);
                if (movies is null)
                {
                    return new ErrorDataResult<ICollection<MovieResponseDto>>(ResultMessages.ErrorListed);
                }
                var movieDtos = _mapper.Map<List<MovieResponseDto>>(movies);
                return new SuccessDataResult<ICollection<MovieResponseDto>>(movieDtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<MovieResponseDto>>($"An error occured while retrieving directors: {e.Message} ");
            }
        }

        public Task<ICollection<MovieResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IDataResult<MovieResponseDto> GetById(Guid id)
        {
            try
            {
                var movie = _movieRepository.Get(m => m.Id == id);
                if (movie is null)
                {
                    return new ErrorDataResult<MovieResponseDto>(ResultMessages.ErrorGetById);
                }
                var dto = _mapper.Map<MovieResponseDto>(movie);
                return new SuccessDataResult<MovieResponseDto>(dto, ResultMessages.SuccessGetById);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<MovieResponseDto>($"An error occured while retrieving directors: {e.Message} ");
            }
        }

        public Task<MovieResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<MovieDetailDto>> GetMoviesWithFullInfo()
        {
            try
            {
                var movies = _movieRepository.GetQueryable().Include(m => m.Actors).Include(m => m.Director).ThenInclude(d => d.Movies).Include(m => m.Category).ToList();
                if (movies is null)
                {
                    return new ErrorDataResult<List<MovieDetailDto>>(ResultMessages.ErrorListed);
                }
                var moviesDto = _mapper.Map<List<MovieDetailDto>>(movies);
                return new SuccessDataResult<List<MovieDetailDto>>(moviesDto, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<MovieDetailDto>>($"An error occurred while retrieving the director: {e.Message}");
            }
        }

        public IResult Insert(MovieAddRequestDto dto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(dto);
                _movieRepository.Add(movie);
                return new SuccessResult(ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while retrieving directors: {e.Message} ");
            }
        }

        public Task InsertAsync(MovieAddRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public IResult Modify(MovieUpdateRequestDto dto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(dto);
                movie.UpdateAt = DateTime.Now;
                _movieRepository.Update(movie);
                return new SuccessResult(ResultMessages.SuccessUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while retrieving directors: {e.Message} ");
            }
        }

        public IResult Remove(Guid id)
        {
            try
            {
                var movie = _movieRepository.Get(m => m.Id == id);
                if (movie == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGetById);
                }
                movie.IsDeleted = true;
                movie.IsActive = false;
                movie.UpdateAt = DateTime.Now;
                _movieRepository.Update(movie);
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while retrieving directors: {e.Message} ");
            }
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MovieUpdateRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
