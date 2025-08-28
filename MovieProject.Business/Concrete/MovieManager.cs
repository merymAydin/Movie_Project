using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using MovieProject.Business.Abstract;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class MovieManager : IMovieService
    {
        public List<Movie> GetByIsActive()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetByIsDeleted()
        {
            throw new NotImplementedException();
        }

        List<Movie> IGenericService<Movie>.GetAll()
        {
            throw new NotImplementedException();
        }

        List<Movie> IMovieService.GetByCategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        

        List<Movie> IMovieService.GetByGreaterThanIMDB(decimal imdb)
        {
            throw new NotImplementedException();
        }

        Movie IGenericService<Movie>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Movie> IMovieService.GetByLessThanIMDB(decimal imdb)
        {
            throw new NotImplementedException();
        }

        List<Movie> IMovieService.GetByName(string name)
        {
            throw new NotImplementedException();
        }

        IQueryable<Movie> IGenericService<Movie>.GetQueryable()
        {
            throw new NotImplementedException();
        }

        void IGenericService<Movie>.Insert(Movie entity)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Movie>.Modify(Movie entity)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Movie>.Remove(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
