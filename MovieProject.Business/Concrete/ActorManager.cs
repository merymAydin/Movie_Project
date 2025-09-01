using System;
using System.Collections.Generic;
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
using MovieProject.Entities.Dtos.Actors;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class ActorManager : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorManager(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public IDataResult<ICollection<ActorDetailDto>> GetActorsWithMovies()
        {
            try
            {
                var actors = _actorRepository.GetQueryable(a => !a.IsDeleted).Include(a => a.Movies).ToList();
                if (actors is null)
                {
                    return new ErrorDataResult<ICollection<ActorDetailDto>>(ResultMessages.ErrorListed);
                }
                var dto = _mapper.Map<ICollection<ActorDetailDto>>(actors);
                return new SuccessDataResult<ICollection<ActorDetailDto>>(dto, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<ActorDetailDto>>($"An error occured while retrieving directors : {e.Message} ");
            }
        }

        public IDataResult<ActorDetailDto> GetActorWithMovies(Guid id)
        {
            try
            {
                //var actor = _actorRepository.GetQueryable(a=>a.Id == id).Include(a=>a.Movies).ToList();
                var actor = _actorRepository.GetQueryable().SingleOrDefault(a => a.Id == id);
                if (actor is null)
                {
                    return new ErrorDataResult<ActorDetailDto>(ResultMessages.ErrorGetById);
                }

                var dto = _mapper.Map<ActorDetailDto>(actor);
                return new SuccessDataResult<ActorDetailDto>(dto, ResultMessages.SuccessGetById);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ActorDetailDto>($"An error occured while retrieving directors : {e.Message} ");
            }
        }

        public IDataResult<ICollection<ActorsResponseDto>> GetAll(bool deleted = false)
        {
            try
            {
                var actors = _actorRepository.GetAll(a => a.IsDeleted == deleted);
                if (actors is null)
                {
                    return new ErrorDataResult<ICollection<ActorsResponseDto>>(ResultMessages.ErrorListed);
                }
                var actorDto = _mapper.Map<ICollection<ActorsResponseDto>>(actors);
                return new SuccessDataResult<ICollection<ActorsResponseDto>>(actorDto, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<ActorsResponseDto>>($"An error occured while retrieving directors : {e.Message} ");
            }
        }

        public Task<ICollection<ActorsResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IDataResult<ActorsResponseDto> GetById(Guid id)
        {
            try
            {
                var actor = _actorRepository.Get(a => a.Id.Equals(id));
                if (actor is null)
                {
                    return new ErrorDataResult<ActorsResponseDto>(ResultMessages.ErrorCategoryGetById);
                }
                var dto = _mapper.Map<ActorsResponseDto>(actor);
                return new SuccessDataResult<ActorsResponseDto>(dto, ResultMessages.SuccessGetById);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ActorsResponseDto>($"An error occured while retrieving directors : {e.Message} ");
            }
        }

        public Task<ActorsResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IResult Insert(ActorsAddRequestDto dto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(dto);
                _actorRepository.Add(actor);
                return new SuccessResult(ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {
                return new ErrorResult(ResultMessages.ErrorCreated);
            }
        }

        public Task InsertAsync(ActorsAddRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public IResult Modify(ActorsUpdateRequestDto dto)
        {
            try
            {
                var actor = _mapper.Map<Actor>(dto);
                actor.UpdateAt = DateTime.Now;
                _actorRepository.Update(actor);
                return new SuccessResult(ResultMessages.SuccessUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"an error occured while retrieving actors : {e.Message}");
            }
        }

        public IResult Remove(Guid id)
        {
            try
            {
                var actor = _actorRepository.Get(a => a.Id == id);
                if (actor == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGetById);
                }
                actor.IsDeleted = true;
                actor.IsActive = false;
                actor.UpdateAt = DateTime.Now;
                _actorRepository.Update(actor);
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult($"an error occured while retrieving actors : {e.Message}");
            }
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ActorsUpdateRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
