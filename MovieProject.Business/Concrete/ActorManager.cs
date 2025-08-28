using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class ActorManager : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorManager(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public List<Actor> GetAll()
        {
            return _actorRepository.GetAll();
        }

        public List<Actor> GetAllByWithMovie()
        {
            return _actorRepository.GetQueryable().Include(a => a.Movies).ToList();
        }

        public List<Actor> GetByFirstName(string firstname)
        {
            return _actorRepository.GetAll(a=>a.FirstName== firstname);
        }

        public Actor GetByFullName(string firstName, string lastName)
        {
            return _actorRepository.Get(a => a.FirstName == firstName && a.LastName == lastName);
        }

        public Actor GetById(Guid id)
        {
            return _actorRepository.Get(a => a.Id == id);
        }

        public List<Actor> GetByIsActive()
        {
            return _actorRepository.GetAll(a=>a.IsActive);
        }

        public List<Actor> GetByIsDeleted()
        {
            return _actorRepository.GetAll(a => a.IsDeleted);
        }

        public List<Actor> GetByLastName(string lastname)
        {
            return _actorRepository.GetAll(a => a.LastName == lastname);
        }

        public IQueryable<Actor> GetQueryable()
        {
            return _actorRepository.GetQueryable();
        }

        public void Insert(Actor entity)
        {
            _actorRepository.Add(entity);
        }

        public void Modify(Actor entity)
        {
            _actorRepository.Update(entity);
        }

        public void Remove(Actor entity)
        {
            _actorRepository.Delete(entity);
        }
    }
}
