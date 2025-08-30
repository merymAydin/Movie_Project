using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category,CategoryResponseDto,CategoryAddRequestDto,CategoryUpdateRequestDto>
    {
        //void Insert(CategoryAddRequestDto dto);
        //void Modify(CategoryUpdateRequestDto dto);
        //void Remove(Guid id);
        //ICollection<CategoryResponseDto> GetAll();
        //CategoryResponseDto GetById(Guid id);
    }
}
