using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ServiceDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ServiceValidator
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceDTO>
    {
        public CreateServiceValidator()
        {
            RuleFor(c => c.ServiceTitle)
                .NotEmpty().WithMessage("Hizmet başlığı boş olamaz.")
                .MinimumLength(2).WithMessage("Hizmet başlığı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Hizmet başlığı en fazla 100 karakter olabilir.");
            RuleFor(c => c.ServiceDescription)
                .NotEmpty().WithMessage("Hizmet açıklaması boş olamaz.")
                .MaximumLength(500).WithMessage("Hizmet açıklaması en fazla 500 karakter olabilir.");
            RuleFor(c => c.ServiceIconUrl)
                .MaximumLength(500).WithMessage("İkon URL en fazla 500 karakter olabilir.");
        }
    }
}
