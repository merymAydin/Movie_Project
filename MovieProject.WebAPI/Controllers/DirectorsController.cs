using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;

namespace MovieProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var directors = _directorService.GetAll();
            return Ok(directors);
        }

        [HttpGet("FullInfo")]
        public IActionResult GetFullInfo()
        {
            var directors = _directorService.GetAllFullInfo();
            var dto = directors.Select(d => new
            {
                ID = d.Id,
                Name = d.FirstName,
                Lastname = d.LastName,
                Image = d.imageUrl,
                BirthDate = d.BirthDate,
                Description = d.Description,
                Movies = d.Movies.Select(m => new
                {
                    Movie = m.Name,
                    Category = m.Category.Name
                }).ToList()
            }).ToList();
            return Ok(dto);
        }

    }
}
