using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.TestimonialDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.TestimonialValidator
{
    public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDTO>
    {
        public UpdateTestimonialValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir referans Id gereklidir.");
            RuleFor(c => c.TestimonialNameSurname)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Ad soyad en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olabilir.");
            RuleFor(c => c.TestimonialTitle)
                .MaximumLength(100).WithMessage("Unvan en fazla 100 karakter olabilir.");
            RuleFor(c => c.TestimonialComment)
                .NotEmpty().WithMessage("Yorum boş olamaz.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");
            RuleFor(c => c.TestimonialImageUrl)
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
