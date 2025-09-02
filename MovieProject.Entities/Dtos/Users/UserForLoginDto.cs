using CoreEntity;

namespace MovieProject.Entities.Dtos.Users;

public sealed record UserForLoginDto(
    string Email,
    string Password
) : IResponseDto;