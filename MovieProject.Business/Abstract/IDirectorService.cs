using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using MovieProject.Entities.Dtos.Directors;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Abstract
{
    public interface IDirectorService : IGenericService<Director,DirectorResponseDto,DirectorsAddRequestDto,DirectorsUpdateRequestDto>
    {
        //List<Director> GetByFirstName(string firstname);
        //List<Director> GetByLastName(string lastname);
        //Director GetByFullName(string firstName, string lastName);
        //List<Director> GetAllFullInfo();
        //void Insert (DirectorsAddRequestDto dto);
        //void Modify(DirectorsUpdateRequestDto dto);
        //void Remove(Guid id);
        //ICollection<DirectorResponseDto> GetAll();
        //DirectorResponseDto GetById(Guid id);
    }
}
