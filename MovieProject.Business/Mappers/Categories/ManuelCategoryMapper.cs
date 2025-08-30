using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Mappers.Categories
{
    public sealed class ManuelCategoryMapper : ICategoryMapper
    {
        public Category ConvertToEntity(CategoryAddRequestDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
        public Category ConvertToEntity(CategoryUpdateRequestDto dto)
        {
            return new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.isActive,
                IsDeleted = dto.isdelete
            };
        }
        public CategoryResponseDto ConvertToResponse(Category category)
        {
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description ?? string.Empty,
            };
        }
        public List<CategoryResponseDto> ConvertToResponseList(List<Category> categories)
        {
            //List<CategoryResponseDto> responseList = new List<CategoryResponseDto>();
            //foreach (var category in categories)
            //{
            //    responseList.Add(ConvertToResponse(category));
            //}
            //return responseList; 
            return categories.Select(x => ConvertToResponse(x)).ToList();
        }
    }
}
