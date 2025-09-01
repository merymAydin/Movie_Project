using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MovieProject.Entities.Entities;
using MovieProject.Business.Mappers.Categories;
using MovieProject.Entities.Dtos.Categories;

namespace MovieProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CategoryAddRequestDto category)
        {
            var result = _categoryService.Insert(category);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(category);
        }

        [HttpPut]
        public IActionResult Update(CategoryUpdateRequestDto category)
        {
            _categoryService.Modify(category);
            return Content("Category was updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryService.Remove(id);
            return Content("Category was deleted successfully...");
        }

        //[HttpGet("active")]
        //public IActionResult GetActiveCategories()
        //{
        //    var category = _categoryService.GetByIsActive();
        //    return Ok(category);
        //}

        //[HttpGet("GetAllFullInfo")]
        //public IActionResult GetAllFullInfo()
        //{
        //    var categories = _categoryService.GetQueryable().Include(c=>c.Movies).ToList();
        //    //List<CategoryResponseDto> dtos = new List<CategoryResponseDto>();
        //    //foreach (var category in categories)
        //    //{
        //    //    dtos.Add(new CategoryResponseDto
        //    //    {
        //    //        Id = category.Id,
        //    //        Name = category.Name ?? string.Empty,
        //    //        Description = category.Description ?? string.Empty
        //    //    });
        //    //}
        //    var dto = _mapper.ConvertToResponseList(categories);
        //    return Ok(dto);
        //}
    }
}
