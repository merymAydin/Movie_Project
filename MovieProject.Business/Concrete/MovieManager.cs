using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Movies;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class MovieManager : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public ICollection<MovieResponseDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovieResponseDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(MovieAddRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public void Modify(MovieUpdateRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        //public List<Movie> GetAll()
        //{
        //    return _movieRepository.GetAll();
        //}

        //public List<Movie> GetByCategoryId(Guid categoryId)
        //{
        //    return _movieRepository.GetAll(m=>m.CategoryId == categoryId).ToList();
        //}

        //public List<Movie> GetByDirectorId(Guid directorId)
        //{
        //    return _movieRepository.GetAll(m => m.DirectorId == directorId).ToList();
        //}

        //public List<Movie> GetByGreaterThanIMDB(decimal imdb)
        //{
        //    return _movieRepository.GetAll(m => m.IMDB >= imdb).ToList();
        //}

        //public Movie GetById(Guid id)
        //{
        //    return _movieRepository.Get(m=>m.Id == id);
        //}

        //public List<Movie> GetByIsActive()
        //{
        //    return _movieRepository.GetAll(m=>m.IsActive);
        //}

        //public List<Movie> GetByIsDeleted()
        //{
        //    return _movieRepository.GetAll(m => m.IsDeleted);
        //}

        //public List<Movie> GetByLessThanIMDB(decimal imdb)
        //{
        //    return _movieRepository.GetAll(m=> m.IMDB <= imdb).ToList();
        //}

        //public List<Movie> GetByMoviesWithFullInfo(Guid actorId)
        //{
        //    return _movieRepository.GetQueryable()
        //        .Include(m => m.Category)
        //        .Include(m => m.Director)
        //        .Include(m => m.Actors)
        //        .ToList();
        //}

        //public List<Movie> GetByMoviesWithFullInfo()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Movie> GetByName(string name)
        //{
        //    return _movieRepository.GetAll(m => m.Name.ToLower() == name.ToLower()).ToList();
        //}

        //public IQueryable<Movie> GetQueryable()
        //{
        //   return _movieRepository.GetQueryable();
        //}

        //public void Insert(Movie entity)
        //{
        //    _movieRepository.Add(entity);
        //}

        //public void Modify(Movie entity)
        //{
        //    _movieRepository.Update(entity);
        //}

        //public void Remove(Movie entity)
        //{
        //    entity.IsDeleted = true;
        //    entity.IsActive = false;
        //    _movieRepository.Delete(entity);
        //}
    }
}
