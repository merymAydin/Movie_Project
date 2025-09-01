using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Actors;
using MovieProject.Entities.Entities;

namespace MovieProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        public ActorsController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _actorService.GetAll(false);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var result = _actorService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("[action]")]
        public ActionResult GetActorWithMovies(Guid id)
        {
            var result = _actorService.GetActorWithMovies(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("[action]")]
        public ActionResult GetActorsWithMovies()
        {
            var result = _actorService.GetActorsWithMovies();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPost]
        public IActionResult Create(ActorsAddRequestDto dto)
        {
            var result = _actorService.Insert(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut]
        public IActionResult Update(ActorsUpdateRequestDto dto)
        {
            var result = _actorService.Modify(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _actorService.Remove(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);

            }
            return Ok(result.Message);
        }
    }
}
