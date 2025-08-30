using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Business;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Directors;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class DirectorManager : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorManager(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public ICollection<DirectorResponseDto> GetAll()
        {
            var directors = _directorRepository.GetQueryable().ToList();
            if (directors is null)
            {
                return new List<DirectorResponseDto>();
            }
            List<DirectorResponseDto> dtos = _mapper.Map<List<DirectorResponseDto>>(directors);
            return dtos;
        }

        public DirectorResponseDto GetById(Guid id)
        {
            var director = _directorRepository.Get(d => d.Id == id);
            if (directors is null)
            {
                throw new KeyNotFoundException($"Director with ID {id} not found");
            }
            DirectorResponseDto dto = _mapper.Map<DirectorResponseDto>(director);
            return dto;
        }

        public void Insert(DirectorsAddRequestDto dto)
        {
            Director director = _mapper.Map<Director>(dto);
            _directorRepository.Add(director);
        }

        public void Modify(DirectorsUpdateRequestDto dto)
        {
            Director director = _mapper.Map<Director>(dto);
            director.UpdateAt = DateTime.Now;
            _directorRepository.Update(director);
        }

        public void Remove(Guid id)
        {
            Director director = _directorRepository.Get(d => d.Id == id);
            director.IsActive = false;
            director.IsDeleted = true;
            director.UpdateAt = DateTime.Now;
            _directorRepository.Update(director);
        }

        //public List<Director> GetAll()
        //{
        //    return _directorRepository.GetAll();
        //}

        //public List<Director> GetByFirstName(string firstname)
        //{
        //    return _directorRepository.GetAll(d => d.FirstName == firstname);
        //}

        //public Director GetByFullName(string firstName, string lastName)
        //{
        //    return _directorRepository.Get(d => d.FirstName == firstName && d.LastName == lastName);
        //}

        //public Director GetById(Guid id)
        //{
        //    //return _directorRepository.Get(d => d.Id == id);
        //    return _directorRepository.GetQueryable(d => d.Id == id).Include(d => d.Movies).FirstOrDefault();
        //}

        //public List<Director> GetByIsActive()
        //{
        //    return _directorRepository.GetAll(d => d.IsActive);
        //}

        //public List<Director> GetByIsDeleted()
        //{
        //    return _directorRepository.GetAll(d => d.IsDeleted);
        //    //return _directorRepository.GetQueryable(d => d.IsDeleted).Include(d=>d.Movies).ToList();
        //}

        //public List<Director> GetByLastName(string lastname)
        //{
        //    return _directorRepository.GetAll(d => d.LastName == lastname);
        //}

        //public IQueryable<Director> GetQueryable()
        //{
        //    return _directorRepository.GetQueryable();
        //}

        //public void Insert(Director entity)
        //{ 
        //    _directorRepository.Add(entity);
        //}

        //public void Modify(Director entity)
        //{
        //    _directorRepository.Update(entity);
        //}

        //public void Remove(Director entity)
        //{
        //    _directorRepository.Delete(entity);
        //}

        //public List<Director> GetAllFullInfo()
        //{
        //    return _directorRepository.GetQueryable()
        //        .Include(d => d.Movies).ThenInclude(m=>m.Category).ToList();
        //}
    }
}
