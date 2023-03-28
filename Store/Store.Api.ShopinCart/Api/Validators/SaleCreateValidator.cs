using FluentValidation;
using Store.Api.ShopinCart.Api.Dtos;

namespace Store.Api.ShopinCart.Api.Validators
{
    public class SaleCreateValidator : AbstractValidator<SaleDto>
    {
        public SaleCreateValidator()
        {
            RuleFor(x => x.InvoiceName).NotEmpty().MaximumLength(50).MinimumLength(2);
            RuleFor(x => x.InvoiceNit).NotEmpty().MaximumLength(20).MinimumLength(1);
            RuleFor(x => x.SubTotal).NotNull();
            RuleFor(x => x.Detail).NotEmpty();
        }
    }
}
