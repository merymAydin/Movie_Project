using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
using System.Text.Json.Serialization;
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
        public IActionResult Create(Category category)
        {
            _categoryService.Insert(category);
            return Ok(category);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            _categoryService.Modify(category);
            return Content("Category was updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var category = _categoryService.GetById(id);
            _categoryService.Remove(category);
            return Content("Category was deleted successfully...");
        }

        [HttpGet("active")]
        public IActionResult GetActiveCategories()
        {
            var category = _categoryService.GetByIsActive();
            return Ok(category);
        }
    }
}
