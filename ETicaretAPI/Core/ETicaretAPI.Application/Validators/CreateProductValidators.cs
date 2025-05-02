using ETicaretAPI.Application.ViewModels.Product;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators
{
    public class CreateProductValidators:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidators()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Məhsulun adını qeyd edin")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Məhsul adı  ən az 3 və ən çox 150 hərfola bilər");

            RuleFor(p => p.Stock)
                .NotEmpty().WithMessage("Bir sayı girin")
                .Must(s => s >= 0).WithMessage("Stok sayı mənfi ola bilməz");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Qiyməti daxil edin")
                .Must(s => s >= 0).WithMessage("Qiymət mənfi ola bilməz");  
        }
    }
}
