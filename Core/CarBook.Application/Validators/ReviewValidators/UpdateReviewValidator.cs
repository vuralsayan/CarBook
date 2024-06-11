using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(p => p.CustomerName)
                            .NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!")
                            .NotNull()
                            .MinimumLength(5).WithMessage("Müşteri adı en az 5 karakter olmalıdır.")
                            .MaximumLength(50).WithMessage("Müşteri adı en fazla 50 karakter olabilir.");


            RuleFor(p => p.CustomerImage)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Comment)
                .NotEmpty().WithMessage("{Lütfen yorum değerini boş geçmeyiniz!")
                .NotNull()
                .MinimumLength(10).WithMessage("Lütfen yorum kısmına en az 10 karakter giriniz.")
                .MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter giriniz.");

            RuleFor(p => p.Star)
                .NotEmpty().WithMessage("{Lütfen puan değerini boş geçmeyiniz!")
                .NotNull()
                .InclusiveBetween(1, 5).WithMessage("{PropertyName} must be between 1 and 5.");
        }
    }
}
