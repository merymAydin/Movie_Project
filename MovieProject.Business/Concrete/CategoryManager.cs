    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreEntity;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ICollection<CategoryResponseDto> GetAll()
        {
            var categories = _categoryRepository.GetQueryable().ToList();
            var categoryDtos = _mapper.Map<ICollection<CategoryResponseDto>>(categories);
            return categoryDtos;
        }

        public CategoryResponseDto GetById(Guid id)
        {
            var category = _categoryRepository.Get(c => c.Id.Equals(id));
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found");
            }
            var categoryDto = _mapper.Map<CategoryResponseDto>(category);
            return categoryDto;
        }

        public CategoryResponseDto GetByIdResponse(Guid id)
        {
            var category = _categoryRepository.Get(c => c.Id.Equals(id));
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found");
            }
            var categoryDto = _mapper.Map<CategoryResponseDto>(category);
            return categoryDto;
        }

        public void Insert(CategoryAddRequestDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            _categoryRepository.Add(category);
        }

        public void Modify(CategoryUpdateRequestDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            category.UpdateAt= DateTime.Now;
            _categoryRepository.Update(category);
        }

        public void Remove(Guid id)
        {
            Category category = _categoryRepository.Get(c=>c.Id.Equals(id));
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found");
            }
            category.IsDeleted= true;
            category.IsActive= false;
            category.UpdateAt= DateTime.Now;
            _categoryRepository.Update(category);
        }
        //public List<Category> GetAll()
        //{
        //    return _categoryRepository.GetQueryable().Include(x=>x.Movies).ToList();
        //}

        //public Category GetById(Guid id)
        //{
        //    return _categoryRepository.Get(c=>c.Id == id);
        //}



        //public List<Category> GetByIsActive()
        //{
        //    return _categoryRepository.GetAll(c=> c.IsActive);
        //}

        //public List<Category> GetByIsDeleted()
        //{
        //    return _categoryRepository.GetAll(c => c.IsDeleted);
        //}

        //public IQueryable<Category> GetQueryable()
        //{
        //    return _categoryRepository.GetQueryable();
        //}

        //public void Insert(Category entity)
        //{
        //    _categoryRepository.Add(entity);
        //}


        //public void Modify(Category entity)
        //{
        //    entity.UpdateAt = DateTime.Now;
        //    _categoryRepository.Update(entity);
        //}



        //public void Remove(Category entity)
        //{
        //    entity.IsDeleted = true;
        //    entity.IsActive = false;
        //    _categoryRepository.Delete(entity);
        //}


    }
}
