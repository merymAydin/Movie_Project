using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Entities;

namespace MovieProject.DataAccess.Repositories.Concrete.EntityFramework
{
    public sealed class EfActorRepository : EfGenericRepository<Actor, MovieDbContext>, IActorRepository
    {
        public EfActorRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
