using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Business;
using Core.Business.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.Business.Constants;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Categories;
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

        public IDataResult<ICollection<DirectorResponseDto>> GetAll(bool deleted = false)
        {
            try
            {
                var directors = _directorRepository.GetAll(d => d.IsDeleted == deleted);
                if (directors is null || !directors.Any())
                {
                    return new ErrorDataResult<ICollection<DirectorResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos = _mapper.Map<ICollection<DirectorResponseDto>>(directors);
                return new SuccessDataResult<ICollection<DirectorResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<DirectorResponseDto>>($"An error occured while retrieving directors : {e.Message}");
            }
        }

        public Task<ICollection<DirectorResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IDataResult<DirectorResponseDto> GetById(Guid id)
        {
            try
            {
                var director = _directorRepository.Get(d => d.Id == id);
                if (director == null)
                {
                    return new ErrorDataResult<DirectorResponseDto>(ResultMessages.ErrorGetById);
                }
                var dto = _mapper.Map<DirectorResponseDto>(director);
                return new SuccessDataResult<DirectorResponseDto>(dto, ResultMessages.SuccessGetById);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DirectorResponseDto>($"An error occured while retrieving the director : {e.Message}");
            }
        }

        public Task<DirectorResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IResult Insert(DirectorsAddRequestDto dto)
        {
            try
            {
                var director = _mapper.Map<Director>(dto);
                _directorRepository.Add(director);
                return new SuccessResult(ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {
                return new ErrorResult(ResultMessages.ErrorCreated);
            }
        }

        public Task InsertAsync(DirectorsAddRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public IResult Modify(DirectorsUpdateRequestDto dto)
        {
            try
            {
                var director = _mapper.Map<Director>(dto);
                director.UpdateAt = DateTime.Now;
                _directorRepository.Update(director);
                return new SuccessResult(ResultMessages.SuccessUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while retriving directors: {e.Message}");
            }
        }

        public IResult Remove(Guid id)
        {
             try
            {
                var director = _directorRepository.Get(d => d.Id == id);
                if (director == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGetById);
                }
                director.IsDeleted = true;
                director.IsActive = false;
                director.UpdateAt=DateTime.Now;
                _directorRepository.Update(director);
                return new SuccessResult(ResultMessages.SuccessUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while retriving directors: {e.Message}");
            }
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DirectorsUpdateRequestDto dto)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<DirectorDetailDto>> GetAllFullInfo()
        {
            try
            {
                var directors = _directorRepository.GetQueryable().Include(d => d.Movies).ThenInclude(m => m.Actors).ToList();
                if (directors is null)
                {
                    return new ErrorDataResult<List<DirectorDetailDto>>(ResultMessages.ErrorListed);
                }

                var directorsDto = _mapper.Map<List<DirectorDetailDto>>(directors);
                return new SuccessDataResult<List<DirectorDetailDto>>(directorsDto, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<DirectorDetailDto>>($"An error occurred while retrieving the director: {e.Message}");
            }
        }
    }
}
