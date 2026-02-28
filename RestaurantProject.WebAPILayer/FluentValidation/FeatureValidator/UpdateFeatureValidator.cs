using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.FeatureDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.FeatureValidator
{
    public class UpdateFeatureValidator : AbstractValidator<UpdateFeatureDTO>
    {
        public UpdateFeatureValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir özellik Id gereklidir.");
            RuleFor(c => c.FeatureSubtitle)
                .NotEmpty().WithMessage("Alt başlık boş olamaz.")
                .MaximumLength(100).WithMessage("Alt başlık en fazla 100 karakter olabilir.");
            RuleFor(c => c.FeatureDescription)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(c => c.FeatureImageUrl)
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
            RuleFor(c => c.FeatureVideoUrl)
                .MaximumLength(500).WithMessage("Video URL en fazla 500 karakter olabilir.");
        }
    }
}
