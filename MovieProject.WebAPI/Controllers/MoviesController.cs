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
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet("FullInfo")]
        public IActionResult GetAllFullInfo()
        {
            var movies = _movieService.GetByMoviesWithFullInfo();
            //var dto = movies.Select(m => new
            //{
            //    m.Id,
            //    m.Name,
            //    m.Description,
            //    m.IMDB,
            //    Category = new
            //    {
            //        m.Category.Name
            //    },
            //    Director = new
            //    {
            //        m.Director.FirstName,
            //        m.Director.LastName,
            //        m.Director.imageUrl
            //    },
            //    Actors = m.Actors.Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName,
            //        a.imageUrl
            //    }).ToList()
            //}).ToList();
            var dto = _mapper.Map<List<MovieResponseDto>>(movies);
            return Ok(dto);
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
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var movie = _movieService.GetById(id);
            _movieService.Remove(movie);
            return Content("Movie was deleted successfully...");
        }
    }
}
