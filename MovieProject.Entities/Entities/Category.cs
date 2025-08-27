using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace MovieProject.Entities.Entities
{
    public sealed class Category : BaseEntity
    {
        public Category()
        {
            Name = string.Empty;
            Description = string.Empty;
            Movies = new HashSet<Movie>();
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
