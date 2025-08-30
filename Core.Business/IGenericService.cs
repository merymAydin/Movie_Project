using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace Core.Business
{
    public interface IGenericService<TEntity,TResponseDto,TCreateDto,TUpdateDto> 
        where TEntity : class,IEntity,new()
        where TResponseDto : class,IResponseDto
        where TCreateDto : class, ICreateDto
        where TUpdateDto : class, IUpdateDto

    {
        void Insert(TCreateDto dto);
        void Modify(TUpdateDto dto);
        void Remove(Guid id);
        ICollection<TResponseDto> GetAll();
        TResponseDto GetById(Guid id);
    }
}
