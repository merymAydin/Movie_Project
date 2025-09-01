using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Utilities.Results;
using CoreEntity;

namespace Core.Business
{
    public interface IGenericService<TEntity,TResponseDto,TCreateDto,TUpdateDto> 
        where TEntity : class,IEntity,new()
        where TResponseDto : class,IResponseDto
        where TCreateDto : class, ICreateDto
        where TUpdateDto : class, IUpdateDto

    {
        IResult Insert(TCreateDto dto);
        IResult Modify(TUpdateDto dto);
        IResult Remove(Guid id);
        IDataResult<ICollection<TResponseDto>> GetAll(bool deleted = false);
        IDataResult<TResponseDto> GetById(Guid id);
    }
}
