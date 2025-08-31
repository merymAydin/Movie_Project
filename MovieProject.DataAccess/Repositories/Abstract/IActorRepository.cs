using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using MovieProject.Entities.Dtos.Actors;
using MovieProject.Entities.Entities;

namespace MovieProject.DataAccess.Repositories.Abstract
{
    public interface IActorRepository : IGenericRepository<Actor>,IGenericRepositoryAsync<Actor>
    {
    }
}
