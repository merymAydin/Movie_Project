using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Business.Utilities.Results;
using CoreEntity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.Business.Constants;
using MovieProject.Business.Validators;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Dtos.Categories;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _categoryValidator;
        private readonly CategoryUpdateValidator _updateValidator;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, CategoryUpdateValidator updateValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _updateValidator = new CategoryUpdateValidator();
            _categoryValidator = new CategoryValidator();
        }

        public IResult Insert(CategoryAddRequestDto dto)
        {
            try
            {
                ValidationResult result = _categoryValidator.Validate(dto);
                if (!result.IsValid)
                {
                    string errorMessages = string.Join(",\n ", result.Errors.Select(e => e.ErrorMessage));
                    return new ErrorResult(errorMessages);
                }
                var category = _mapper.Map<Category>(dto);
                _categoryRepository.Add(category);
                return new SuccessResult(ResultMessages.SuccessCategoryCreated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occurred while adding the category :{e.Message}");
            }
        }
        public IResult Modify(CategoryUpdateRequestDto dto)
        {
            try
            {
                ValidationResult result = _updateValidator.Validate(dto);
                if (!result.IsValid)
                {
                    string errormessages = string.Join(",\n", result.Errors.Select(e => e.ErrorMessage));
                    return new ErrorResult($"{ResultMessages.ErrorCategoryUpdated},\nHataListesi\n{errormessages}");
                }
                var category = _mapper.Map<Category>(dto);
                category.UpdateAt = DateTime.Now;

                _categoryRepository.Update(category);
                return new SuccessResult(ResultMessages.SuccessCategoryUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while updating the category{e.Message}");

            }
        }

        public IResult Remove(Guid id)
        {
            try
            {
                var category = _categoryRepository.Get(c => c.Id.Equals(id));
                if (category is null)
                {
                    return new ErrorResult(ResultMessages.ErrorCategoryGetById);
                }
                category.IsDeleted = true;
                category.IsActive = false;
                category.UpdateAt = DateTime.Now;
                _categoryRepository.Update(category);
                return new SuccessResult(ResultMessages.SuccessCategoryDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult($"An error occured while updating the category{e.Message}");
            }
           
        }
        public IDataResult<ICollection<CategoryResponseDto>> GetAll(bool deleted)
        {
            try
            {
                var categories = _categoryRepository.GetAll(c => c.IsDeleted == deleted);
                if (categories is null || !categories.Any())
                {
                    return new ErrorDataResult<ICollection<CategoryResponseDto>>(ResultMessages.ErrorCategoryListed);
                }
                var categoryDtos = _mapper.Map<ICollection<CategoryResponseDto>>(categories);
                return new SuccessDataResult<ICollection<CategoryResponseDto>>(categoryDtos, ResultMessages.SuccessCategoryListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ICollection<CategoryResponseDto>>($"An error occured while retrieving categories : {e.Message}");
            }
            
        }
        public IDataResult<CategoryResponseDto> GetById(Guid id)
        {
            try
            {
                var category = _categoryRepository.Get(c => c.Id.Equals(id) && !c.IsDeleted);
                if (category == null)
                {
                    return new ErrorDataResult<CategoryResponseDto>(ResultMessages.ErrorCategoryGetById);
                }
                var dto = _mapper.Map<CategoryResponseDto>(category);
                return new SuccessDataResult<CategoryResponseDto>(dto, ResultMessages.SuccessCategoryGetById);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CategoryResponseDto>($"an error occured while retrieving the category : {e.Message}");
            }

        }
        public async Task InsertAsync(CategoryAddRequestDto dto)
        {
            try
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto), "CategoryAddRequestDto cannot be null");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task UpdateAsync(CategoryUpdateRequestDto dto)
        {
            throw new NotImplementedException();
        }
        public async Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<CategoryResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<CategoryResponseDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<CategoryResponseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
