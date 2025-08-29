    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
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
            var movies = _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var movie = _movieService.GetById(id);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movieService.Insert(movie);
            return Ok(movie);
        }

        [HttpPut]
        public IActionResult Update(Movie movie)
        {
            _movieService.Modify(movie);
            return Ok(movie);
        }
    }
}
