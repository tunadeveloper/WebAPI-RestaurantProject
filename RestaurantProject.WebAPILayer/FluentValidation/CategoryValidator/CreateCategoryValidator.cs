using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.CategoryDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.CategoryValidator
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.CategoryName)
              .NotEmpty().WithMessage("Kategori adı boş olamaz.")
              .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.")
              .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
        }
    }
}
