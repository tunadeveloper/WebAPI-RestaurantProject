using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ImageDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ImageValidator
{
    public class UpdateImageValidator : AbstractValidator<UpdateImageDTO>
    {
        public UpdateImageValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir görsel Id gereklidir.");
            RuleFor(c => c.ImageTitle)
                .NotEmpty().WithMessage("Görsel başlığı boş olamaz.")
                .MaximumLength(100).WithMessage("Görsel başlığı en fazla 100 karakter olabilir.");
            RuleFor(c => c.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
