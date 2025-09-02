using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Security.Jwt;
using Core.Business.Utilities.Hashing;
using Core.Business.Utilities.Results;
using CoreEntity.Concrete;
using MovieProject.Business.Abstract;
using MovieProject.Business.Constants;
using MovieProject.Entities.Dtos.Users;

namespace MovieProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByMail(userForLoginDto.Email);
            if (user == null)
            {
                return new ErrorDataResult<User>(ResultMessages.ErrorGetById);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(ResultMessages.ErrorPassword);
            }
            return new SuccessDataResult<User>(user.Data, ResultMessages.SuccessLogin);
        }
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                firstName = userForRegisterDto.Firstname,
                lastName = userForRegisterDto.Lastname,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = ""
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, ResultMessages.SuccessUserRegister);
        }
        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Data != null)
            {
                return new ErrorResult(ResultMessages.UserExits);
            }
            return new SuccessResult();
        }
    }
}
