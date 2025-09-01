    using AutoMapper;
    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
using MovieProject.Entities.Dtos.Movies;
using MovieProject.Entities.Entities;

namespace MovieProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllFullInfo() //ödev olarak tamamla
        {
            var result = _movieService.GetMoviesWithFullInfo();
            if (!result.Success)
            {
                return BadRequest(result.Data);
            }
            return Ok(result.Data);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute(Name = "id")] Guid id)
        {
            var result = _movieService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] MovieAddRequestDto dto)
        {
            var result = _movieService.Insert(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut]
        public IActionResult Update([FromBody] MovieUpdateRequestDto dto)
        {
            var result = _movieService.Modify(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute(Name = "id")] Guid id)
        {
            var result = _movieService.Remove(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

    }
}
