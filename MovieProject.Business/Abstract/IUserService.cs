using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.Business.Utilities.Results;
using CoreEntity.Concrete;
using MovieProject.Entities.Dtos.Users;

namespace MovieProject.Business.Abstract
{
    public interface IUserService : IGenericService<User, UserResponseDto, UserForRegisterDto, UserUpdateRequestDto>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
    }
}
