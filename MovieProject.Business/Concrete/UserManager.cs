using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Business.Utilities.Results;
using CoreEntity.Concrete;
using MovieProject.Business.Abstract;
using MovieProject.Business.Constants;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Users;

namespace MovieProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IResult Add(User user)
        {
            _userRepository.Add(user);
            return new SuccessResult(ResultMessages.SuccessUserRegister);
        }

        public IDataResult<ICollection<UserResponseDto>> GetAll(bool deleted = false)
        {
            var users = _userRepository.GetAll();
            if (users is null)
            {
                return new ErrorDataResult<ICollection<UserResponseDto>>(ResultMessages.ErrorListed);
            }
            var usersDto = _mapper.Map<List<UserResponseDto>>(users);
            return new SuccessDataResult<ICollection<UserResponseDto>>(usersDto, ResultMessages.SuccessListed);
        }
        public IDataResult<UserResponseDto> GetById(Guid id)
        {
            var user = _userRepository.Get(u => u.Id == id);
            if (user is null)
            {
                return new ErrorDataResult<UserResponseDto>(ResultMessages.ErrorGetById);
            }

            var usersDto = _mapper.Map<UserResponseDto>(user);
            return new SuccessDataResult<UserResponseDto>(usersDto, ResultMessages.SuccessGetById);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userRepository.Get(u => u.Email == email);
            if (user is null)
            {
                return new ErrorDataResult<User>(ResultMessages.ErrorGetById);
            }
            return new SuccessDataResult<User>(user, ResultMessages.SuccessGetById);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var claims = _userRepository.GetOperationClaims(user);
            if (claims is null)
            {
                return new ErrorDataResult<List<OperationClaim>>(claims, ResultMessages.SuccessListed);
            }
            return new SuccessDataResult<List<OperationClaim>>(claims, ResultMessages.SuccessListed);
        }

        public IResult Insert(UserForRegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _userRepository.Add(user);
            return new SuccessResult(ResultMessages.SuccessUserRegister);
        }
        public IResult Modify(UserUpdateRequestDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _userRepository.Update(user);
            return new SuccessResult(ResultMessages.SuccessUpdated);
        }
        public IResult Remove(Guid id)
        {
            var user = _userRepository.Get(u => u.Id == id);
            if (user is null)
            {
                return new ErrorResult(ResultMessages.ErrorGetById);
            }
            _userRepository.Delete(user);
            return new SuccessResult(ResultMessages.SuccessDeleted);
        }


    }
}
