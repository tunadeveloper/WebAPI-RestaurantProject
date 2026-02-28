using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ImageDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ImageValidator
{
    public class CreateImageValidator : AbstractValidator<CreateImageDTO>
    {
        public CreateImageValidator()
        {
            RuleFor(c => c.ImageTitle)
                .NotEmpty().WithMessage("Görsel başlığı boş olamaz.")
                .MaximumLength(100).WithMessage("Görsel başlığı en fazla 100 karakter olabilir.");
            RuleFor(c => c.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
