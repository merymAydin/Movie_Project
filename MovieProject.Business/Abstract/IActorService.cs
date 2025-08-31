using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using MovieProject.Entities.Dtos.Actors;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Abstract
{
    public interface IActorService : IGenericService<Actor,ActorsResponseDto,ActorsAddRequestDto,ActorsUpdateRequestDto>,IGenericServiceAsync<Actor, ActorsResponseDto, ActorsAddRequestDto, ActorsUpdateRequestDto>
    {
        //List<Actor> GetByFirstName(string firstname);
        //List<Actor> GetByLastName(string lastname);
        //Actor GetByFullName(string firstName, string lastName);
        //List<Actor> GetAllByWithMovie();
    }
}
