using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using CoreEntity.Concrete;

namespace MovieProject.DataAccess.Repositories.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<OperationClaim> GetOperationClaims(User user);

    }
}
