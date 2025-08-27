using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace MovieProject.Entities.Entities
{
    public sealed class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string imageUrl { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Movie> Movies { get; set; }
    }
}
