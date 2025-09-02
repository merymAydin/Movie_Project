using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using CoreEntity.Concrete;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstract;

namespace MovieProject.DataAccess.Repositories.Concrete.EntityFramework
{
    public class EfUserRepository : EfGenericRepository<User, MovieDbContext>, IUserRepository
    {
        public EfUserRepository(MovieDbContext context) : base(context)
        {

        }
        public List<OperationClaim> GetOperationClaims(User user)
        {
            var claims = from OperationClaim in Context.OperationClaims
                join UserOperationClaim in Context.UserOperationClaims on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                where UserOperationClaim.UserId == user.Id
                select new OperationClaim()
                {
                    Id = OperationClaim.Id,
                    Name = OperationClaim.Name
                };
            return claims.ToList();
        }
    }
}
