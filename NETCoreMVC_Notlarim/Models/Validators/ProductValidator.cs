using FluentValidation;

namespace NETCoreMVC_Notlarim.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("email bos olmamalidir");
            RuleFor(x => x.Email).EmailAddress().WithMessage("LUTFEN DOGRU BIR EMAIL ADRESI GIRINIZ");

            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("LUTFEN PRODUCT NAME BOS GECMEYINIZ");
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("LUTFEN MAXIMUM 100 KARAKTER GIRINIZ");
        }
    }
}
