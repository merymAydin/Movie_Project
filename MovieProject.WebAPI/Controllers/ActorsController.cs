using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
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
        public IActionResult GetAll()
        {
            var directors = _actorService.GetAll();
            return Ok(directors);
        }
        [HttpGet("{id}")]
        public IActionResult GetDirector(string id)
        {
            Actor actor = _actorService.GetById(Guid.Parse(id));
            var dto = new
            {
                actor.Id,
                actor.FirstName,
                actor.LastName,
                actor.imageUrl,
                actor.BirthDate,
                actor.Description
            };
            return Ok(dto);
        }
        [HttpGet("GetAllIsActive")]
        public IActionResult GetAllIsActive()
        {
            var actors = _actorService.GetByIsActive();
            var dto = actors.Select(d => new
            {
                d.Id,
                d.FirstName,
                d.LastName,
                d.imageUrl,
                d.BirthDate,
                d.Description,
                Movies = d.Movies.Select(m => new
                {
                    m.Name
                }).ToList()
            }).ToList();
            return Ok(dto);
        }
    }
}
