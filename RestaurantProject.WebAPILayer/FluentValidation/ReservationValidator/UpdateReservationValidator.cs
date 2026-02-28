using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ReservationDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ReservationValidator
{
    public class UpdateReservationValidator : AbstractValidator<UpdateReservationDTO>
    {
        public UpdateReservationValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir rezervasyon Id gereklidir.");
            RuleFor(c => c.ReservationNameSurname)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Ad soyad en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olabilir.");
            RuleFor(c => c.ReservationEmail)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
            RuleFor(c => c.ReservationPhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olabilir.");
            RuleFor(c => c.ReservationDate)
                .NotEmpty().WithMessage("Rezervasyon tarihi boş olamaz.");
            RuleFor(c => c.ReservationCountOfPeople)
                .GreaterThan(0).WithMessage("Kişi sayısı 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(50).WithMessage("Kişi sayısı en fazla 50 olabilir.");
            RuleFor(c => c.ReservationMessage)
                .MaximumLength(500).WithMessage("Mesaj en fazla 500 karakter olabilir.");
        }
    }
}
