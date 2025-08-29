using CoreEntity;

namespace MovieProject.Entities.Dtos.Categories;

public sealed record CategoryAddRequestDto : IDto
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}