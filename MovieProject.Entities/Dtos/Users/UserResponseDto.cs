using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace MovieProject.Entities.Dtos.Users
{
    public sealed record UserResponseDto(
        Guid Id,
        string Firstname,
        string Lastname,
        string Email,
        string Status
    ) : IResponseDto;
}
