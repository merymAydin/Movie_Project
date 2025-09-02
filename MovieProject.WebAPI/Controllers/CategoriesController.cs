using System.Text.Json.Serialization;
using Core.Business.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.Business.Mappers.Categories;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Entities;

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
            var result = _categoryService.GetAll(false);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            //var categories = _categoryService.GetAll();
            //return Ok(categories);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllDeleted()
        {
            var result = _categoryService.GetAll(true);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _categoryService.GetById(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
            //var category = _categoryService.GetById(id);
            //return Ok(category);
        }
        [HttpPost]
        public IActionResult Create(CategoryAddRequestDto category)
        {
            var result = _categoryService.Insert(category);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut]
        public IActionResult Update(CategoryUpdateRequestDto category)
        {
            var result = _categoryService.Modify(category);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _categoryService.Remove(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }


        //[HttpGet("active")]
        //public IActionResult GetActiveCategories()
        //{
        //    return Ok();
        //}
        //[HttpGet("GetAllFullInfo")]
        //public IActionResult GetAllFullInfo()
        //{
        //var categories = _categoryService.GetQueryable().Include(c=>c.Movies).ToList();
        //List<CategoryResponseDto> dtos = new List<CategoryResponseDto>();
        //foreach (var category in categories) 
        //{
        //    dtos.Add(new CategoryResponseDto()
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //        Description = category.Description ?? string.Empty,
        //    });
        //}
        //var x = new DirectorsResponseDto(Guid.NewGuid(), "Akın","Cengiz","asdafs",DateTime.Now,"asfgsfgdhezf");
        //var y = new DirectorsResponseDto(Guid.NewGuid(), "Akın", "Cengiz", "asd", DateTime.Now, "asdf")
        //{

        //};

        //var dto = _mapper.ConvertToResponseList(categories);
        //return Ok(dto);
        //}
    }
}
