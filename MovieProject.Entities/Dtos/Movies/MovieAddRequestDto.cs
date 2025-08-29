using CoreEntity;

namespace MovieProject.Entities.Dtos.Movies;

public sealed record MovieAddRequestDto : IDto
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal IMDB { get; init; }
    public DateTime PublishDate { get; init; }
    public string imageUrl { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public Guid DirectorId { get; init; }
}