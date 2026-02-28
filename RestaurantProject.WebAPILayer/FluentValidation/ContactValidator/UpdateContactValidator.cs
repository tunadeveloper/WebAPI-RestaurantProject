using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ContactDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ContactValidator
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactDTO>
    {
        public UpdateContactValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir iletişim Id gereklidir.");
            RuleFor(c => c.ContactAddress)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olabilir.");
            RuleFor(c => c.ContactPhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olabilir.");
            RuleFor(c => c.ContactEmail)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
            RuleFor(c => c.ContactOpenTimes)
                .MaximumLength(200).WithMessage("Açılış saatleri en fazla 200 karakter olabilir.");
            RuleFor(c => c.ContactMapLocation)
                .MaximumLength(1000).WithMessage("Harita konumu en fazla 1000 karakter olabilir.");
        }
    }
}
