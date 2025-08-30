using CoreEntity;

namespace MovieProject.Entities.Dtos.Actors;

public sealed record ActorsResponseDto(
    Guid Id,
    string Firstname,
    string LastName,
    string? imageUrl,
    DateTime? BirthDate,
    string Description,
    bool isActive = true
) : IResponseDto;