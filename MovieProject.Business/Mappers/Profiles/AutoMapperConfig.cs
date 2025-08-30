using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieProject.Entities.Dtos.Actors;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Dtos.Directors;
using MovieProject.Entities.Dtos.Movies;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Mappers.Profiles
{
    public sealed class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Mapping configurations for Category entity and DTOs
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
            CreateMap<CategoryAddRequestDto, Category>();
            CreateMap<CategoryUpdateRequestDto, Category>();

            //Mapping configurations for Director entity and Dtos
            CreateMap<Director, DirectorResponseDto>();
            CreateMap<DirectorsAddRequestDto, Director>();
            CreateMap<DirectorsUpdateRequestDto, Director>();

            //Mapping configurations for movie entity and DTOs
            CreateMap<Movie, MovieResponseDto>();
            CreateMap<MovieAddRequestDto, Movie>();
            CreateMap<MovieUpdateRequestDto, Movie>();
            CreateMap<Movie, MovieDetailDto>().ForMember(m => m.Players, option => option.MapFrom(m => m.Actors.Select(a => $"{a.FirstName}{a.LastName}").ToHashSet()));

            //Mapping configurations for actor entity and DTOs
            CreateMap<Actor, ActorsResponseDto>();
            CreateMap<ActorsAddRequestDto, Actor>();
            CreateMap<ActorsUpdateRequestDto, Actor>();
        }
    }
}
