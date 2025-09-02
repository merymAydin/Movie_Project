using CoreEntity;

namespace MovieProject.Entities.Dtos.Users;

public sealed record UserUpdateRequestDto(
    string Firstname,
    string Lastname,
    string Email,
    string Password,
    bool IsActive,
    bool IsDelete
) : IUpdateDto;