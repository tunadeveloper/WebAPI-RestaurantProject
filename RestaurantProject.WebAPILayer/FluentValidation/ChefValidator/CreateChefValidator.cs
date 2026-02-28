using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ChefDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ChefValidator
{
    public class CreateChefValidator : AbstractValidator<CreateChefDTO>
    {
        public CreateChefValidator()
        {
            RuleFor(c => c.ChefNameSurname)
                .NotEmpty().WithMessage("Şef adı soyadı boş olamaz.")
                .MinimumLength(2).WithMessage("Şef adı soyadı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Şef adı soyadı en fazla 100 karakter olabilir.");
            RuleFor(c => c.ChefTitle)
                .NotEmpty().WithMessage("Şef unvanı boş olamaz.")
                .MaximumLength(50).WithMessage("Şef unvanı en fazla 50 karakter olabilir.");
            RuleFor(c => c.ChefDescription)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(c => c.ChefImageUrl)
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
