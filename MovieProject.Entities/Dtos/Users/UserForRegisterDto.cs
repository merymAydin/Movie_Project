using CoreEntity;

namespace MovieProject.Entities.Dtos.Users;

public sealed record UserForRegisterDto(
    string Firstname,
    string Lastname,
    string Email,
    string Password
) : ICreateDto;