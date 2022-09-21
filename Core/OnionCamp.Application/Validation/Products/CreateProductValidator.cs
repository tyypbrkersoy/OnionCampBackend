using FluentValidation;
using OnionCamp.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Application.Validation.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Product_Create>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Ürün Adını Doldur La!")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen Ürün Adını 150 İle 2 Karakter Arasında Giriniz La!");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Bir Stok Bilgisi Giriniz La!")
                .Must(s=>s >= 0)
                    .WithMessage("Ürün Stok Değeri Sıfırdan Büyük Olmalı La!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Bir Fiyat Giriniz La!")
                .Must(s => s >= 0)
                    .WithMessage("Ürün Fiyatı Sıfırdan Büyük Olmalı La!");
        }
    }
}
