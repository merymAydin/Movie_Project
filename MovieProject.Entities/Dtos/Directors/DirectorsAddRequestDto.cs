using CoreEntity;

namespace MovieProject.Entities.Dtos.Directors;

public sealed record DirectorsAddRequestDto(
    string FirstName,
    string LastName,
    string ImageUrl, 
    DateTime BirthDate,
    string Description
) : ICreateDto;