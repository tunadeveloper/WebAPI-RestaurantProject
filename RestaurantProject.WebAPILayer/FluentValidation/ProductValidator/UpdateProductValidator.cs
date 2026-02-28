using FluentValidation;
using RestaurantProject.WebAPILayer.DTOs.ProductDTOs;

namespace RestaurantProject.WebAPILayer.FluentValidation.ProductValidator
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Geçerli bir ürün Id gereklidir.");
            RuleFor(c => c.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");
            RuleFor(c => c.ProductDescription)
                .MaximumLength(500).WithMessage("Ürün açıklaması en fazla 500 karakter olabilir.");
            RuleFor(c => c.ProductPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0 veya daha büyük olmalıdır.");
            RuleFor(c => c.ProductImageUrl)
                .MaximumLength(500).WithMessage("Ürün görsel URL en fazla 500 karakter olabilir.");
            RuleFor(c => c.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori Id gereklidir.");
        }
    }
}
