using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.MessageDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.MessageValidator
{
    public class UpdateMessageValidator : AbstractValidator<UpdateMessageDTO>
    {
        public UpdateMessageValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir mesaj Id gereklidir.");
            RuleFor(c => c.MessageNameSurname)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Ad soyad en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olabilir.");
            RuleFor(c => c.MessageEmail)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
            RuleFor(c => c.MessageSubject)
                .NotEmpty().WithMessage("Konu boş olamaz.")
                .MaximumLength(200).WithMessage("Konu en fazla 200 karakter olabilir.");
            RuleFor(c => c.MessageDetails)
                .NotEmpty().WithMessage("Mesaj içeriği boş olamaz.")
                .MaximumLength(2000).WithMessage("Mesaj içeriği en fazla 2000 karakter olabilir.");
        }
    }
}
