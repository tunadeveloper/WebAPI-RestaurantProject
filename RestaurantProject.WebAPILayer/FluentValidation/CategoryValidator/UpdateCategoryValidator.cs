using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.CategoryDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.CategoryValidator
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir kategori Id gereklidir.");
            RuleFor(c => c.CategoryName)
              .NotEmpty().WithMessage("Kategori adı boş olamaz.")
              .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.")
              .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
        }
    }
}
