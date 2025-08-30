using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace MovieProject.Entities.Dtos.Actors
{
    public sealed record ActorsAddRequestDto(
        string FirstName,
        string LastName,
        string? imageUrl,
        DateTime? BirthDate,
        string? Description
    ) : IDto;
}
