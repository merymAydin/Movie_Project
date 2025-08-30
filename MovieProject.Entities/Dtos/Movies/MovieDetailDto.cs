using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace MovieProject.Entities.Dtos.Movies
{
    public sealed record MovieDetailDto : IResponseDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal IMDB { get; init; }
        public DateTime PublishDate { get; init; }
        public string imageUrl { get; init; } = string.Empty;
        public bool isActive { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string DirectorFirstName { get; init; } = string.Empty;
        public string DirectorLastName { get; init; } = string.Empty;
        public HashSet<string> Players { get; init; } = new HashSet<string>();
    }
}
