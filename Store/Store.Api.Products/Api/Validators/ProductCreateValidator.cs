using FluentValidation;
using Store.Api.Products.Api.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Api.Products.Api.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductAddDto>
    {
        public ProductCreateValidator() {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150).MinimumLength(2);
            RuleFor(x => x.Code).NotEmpty().MaximumLength(25).MinimumLength(1);
            RuleFor(x => x.ForInventory).NotNull();
            RuleFor(x => x.ForSale).NotNull();
            RuleFor(x => x.Price).NotNull();
        }
    }
}
