using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MovieProject.Entities.Dtos.Categories;

namespace MovieProject.Business.Validators
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateRequestDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Category name cannot be empty.")
                .Length(2, 50).WithMessage("Category name must be between 2 and 50");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Category description cannot be empty")
                .Length(10, 200).WithMessage("Category description must be between 10 and 20 characters long");
            RuleFor(c => c.isActive).NotNull().WithMessage("isActive cannot be null");
            RuleFor(c => c.isdelete).NotNull().WithMessage("isDeleted cannot be null");
        }
    }
}
