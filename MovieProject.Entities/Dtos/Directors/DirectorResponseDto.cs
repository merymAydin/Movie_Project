using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace MovieProject.Entities.Dtos.Directors
{
    public sealed record DirectorResponseDto(
        Guid Id,
        string FirstName,
        string LastName,
        string ImageUrl,
        DateTime BirthDate,
        string Description
    ) : IResponseDto;
}
