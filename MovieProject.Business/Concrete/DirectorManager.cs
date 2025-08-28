using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class DirectorManager : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorManager(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public List<Director> GetAll()
        {
            return _directorRepository.GetAll();
        }

        public List<Director> GetByFirstName(string firstname)
        {
            return _directorRepository.GetAll(d => d.FirstName == firstname);
        }

        public Director GetByFullName(string firstName, string lastName)
        {
            return _directorRepository.Get(d => d.FirstName == firstName && d.LastName == lastName);
        }

        public Director GetById(Guid id)
        {
            return _directorRepository.Get(d => d.Id == id);
        }

        public List<Director> GetByIsActive()
        {
            return _directorRepository.GetAll(d => d.IsActive);
        }

        public List<Director> GetByIsDeleted()
        {
            return _directorRepository.GetAll(d => d.IsDeleted);
            //return _directorRepository.GetQueryable(d => d.IsDeleted).Include(d=>d.Movies).ToList();
        }

        public List<Director> GetByLastName(string lastname)
        {
            return _directorRepository.GetAll(d => d.LastName == lastname);
        }

        public IQueryable<Director> GetQueryable()
        {
            return _directorRepository.GetQueryable();
        }

        public void Insert(Director entity)
        { 
            _directorRepository.Add(entity);
        }

        public void Modify(Director entity)
        {
            _directorRepository.Update(entity);
        }

        public void Remove(Director entity)
        {
            _directorRepository.Delete(entity);
        }
    }
}
