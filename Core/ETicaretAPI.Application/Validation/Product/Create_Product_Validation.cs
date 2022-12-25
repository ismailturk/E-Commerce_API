using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validation.Product
{
    public class Create_Product_Validation : AbstractValidator<VM_Create_Product>
    {
        public Create_Product_Validation()
        {
            RuleFor(x => x.Name).NotEmpty()
                                 .NotNull()
                                 .WithMessage("Ürün adı boş olamaz")
                                 .MaximumLength(100)
                                 .MinimumLength(2)
                                 .WithMessage("Ürün adı 2 ile 100 karakter arasında olmalıdır.");


            RuleFor(x => x.Stock).NotEmpty()
                                .NotNull()
                                .WithMessage("Stok sayısı boş olamaz")
                                .Must(x => x >= 0)
                                .WithMessage("stok sayısı 0'dan az olamaz");


            RuleFor(x => x.Price).NotEmpty()
                               .NotNull()
                               .WithMessage("Fiyat boş olamaz")
                               .Must(x => x >= 0)
                               .WithMessage("Fiyat 0'dan az olamaz");

        }

    }
}
