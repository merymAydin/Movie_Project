using CoreEntity;

namespace MovieProject.Entities.Dtos.Directors;

public sealed record DirectorsUpdateRequestDto(
    Guid id,
    string FirstName,
    string LastName,
    string ImageUrl,
    DateTime BirthDate,
    string Description,
    bool isActive = true,
    bool isDeleted = false
) : IUpdateDto;