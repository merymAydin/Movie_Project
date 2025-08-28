using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Business.Abstract;
using MovieProject.DataAccess.Repositories.Abstract;
using MovieProject.Entities.Entities;

namespace MovieProject.Business.Concrete
{
    public sealed class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAll()
        {
            return _categoryRepository.GetQueryable().Include(x=>x.Movies).ToList();
        }

        public Category GetById(Guid id)
        {
            return _categoryRepository.Get(c=>c.Id == id);
        }

        public List<Category> GetByIsActive()
        {
            return _categoryRepository.GetAll(c=> c.IsActive);
        }

        public List<Category> GetByIsDeleted()
        {
            return _categoryRepository.GetAll(c => c.IsDeleted);
        }

        public IQueryable<Category> GetQueryable()
        {
            return _categoryRepository.GetQueryable();
        }

        public void Insert(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void Modify(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public void Remove(Category entity)
        {
            _categoryRepository.Delete(entity);
        }
    }
}
