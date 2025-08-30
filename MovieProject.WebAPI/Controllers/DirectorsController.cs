using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.Entities.Dtos.Directors;
using MovieProject.Entities.Entities;

namespace MovieProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var directors = _directorService.GetAll();
            return Ok(directors);
        }

        //[HttpGet("FullInfo")]
        //public IActionResult GetFullInfo()
        //{
        //    //var directors = _directorService.GetAllFullInfo();
        //    //var dto = directors.Select(d => new
        //    //{
        //    //    d.Id,
        //    //    d.FirstName,
        //    //    d.LastName,
        //    //    d.imageUrl,
        //    //    d.BirthDate,
        //    //    d.Description,
        //    //    Movies = d.Movies.Select(m => new
        //    //    {
        //    //         m.Name,
        //    //        Category = m.Category.Name,
        //    //        m.Category.Description
        //    //    }).ToList()
        //    //}).ToList();
        //    var dto = _mapper.Map<List<DirectorResponseDto>>(directors);
        //    return Ok(dto);
        //}
        [HttpGet("{id}")]
        public IActionResult GetDirector(string id)
        {
            Director director = _directorService.GetById(Guid.Parse(id));
            var dto = new
            {
                director.Id,
                director.FirstName,
                director.LastName,
                director.imageUrl,
                director.BirthDate,
                director.Description,
                Movies = director.Movies.Select(m => new
                {
                    m.Name
                }).ToList()
            };
            return Ok(dto);
        }
        [HttpGet("GetAllIsActive")]
        public IActionResult GetAllIsActive()
        {
            var directors = _directorService.GetByIsActive();
            var dto = directors.Select(d => new
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
