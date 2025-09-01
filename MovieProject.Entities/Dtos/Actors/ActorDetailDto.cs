using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;
using MovieProject.Entities.Dtos.Movies;

namespace MovieProject.Entities.Dtos.Actors
{
    public sealed record ActorDetailDto

    (Guid Id,
        string Firstname,
        string LastName,
        string? imageUrl,
        DateTime? BirthDate,
        string Description,
        List<MovieResponseDto> Movies,
        bool isActive
    ) : IResponseDto;
}
