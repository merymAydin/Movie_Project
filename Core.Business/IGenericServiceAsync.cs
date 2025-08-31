using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;

namespace Core.Business
{
    public interface IGenericServiceAsync<TEntity, TResponseDto, in TCreateDto, in TUpdateDto>
        where TEntity : class, IEntity, new()
        where TResponseDto : class, IResponseDto
        where TCreateDto : class, ICreateDto
        where TUpdateDto : class, IUpdateDto
    {
        Task InsertAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDto dto);
        Task RemoveAsync(Guid id);
        Task<ICollection<TResponseDto>> GetAllAsync();
        Task<TResponseDto> GetByIdAsync(Guid id);
    }
}
