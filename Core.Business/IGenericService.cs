using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace Core.Business
{
    public interface IGenericService<T> where T : class,IEntity,new()
    {
        void Insert(T entity);
        void Modify(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(Guid id);
        IQueryable<T> GetQueryable();
        List<T> GetByIsActive();
        List<T> GetByIsDeleted();
    }
}
