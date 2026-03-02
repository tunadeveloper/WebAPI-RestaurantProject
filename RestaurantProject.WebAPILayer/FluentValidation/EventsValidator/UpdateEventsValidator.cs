using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.EventsDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.EventsValidator
{
    public class UpdateEventsValidator : AbstractValidator<UpdateEventsDTO>
    {
        public UpdateEventsValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir etkinlik Id gereklidir.");
            RuleFor(c => c.EventsTitle)
                .NotEmpty().WithMessage("Etkinlik başlığı boş olamaz.")
                .MinimumLength(2).WithMessage("Etkinlik başlığı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Etkinlik başlığı en fazla 100 karakter olabilir.");
            RuleFor(c => c.EventsDescription)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(c => c.EventsImageUrl)
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
            RuleFor(c => c.EventsPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0 veya daha büyük olmalıdır.");
        }
    }
}
