using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Abstract
{
    public interface IDirectorService : IGenericService<Director>
    {
        List<Director> GetByFirstName(string firstname);
        List<Director> GetByLastName(string lastname);
        Director GetByFullName(string firstName, string lastName);
        List<Director> GetAllFullInfo();
    }
}
