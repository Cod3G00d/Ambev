using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for the SaleItem entity
    /// </summary>
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        /// <summary>
        /// Constructor for the validator
        /// </summary>
        public SaleItemValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is required");

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Product name is required")
                .MaximumLength(200)
                .WithMessage("Product name cannot exceed 200 characters");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be greater than zero");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount cannot be negative");

            RuleFor(x => x.TotalItemAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total item amount cannot be negative");

            RuleFor(x => x.Sale)
                .NotNull()
                .WithMessage("Item must be associated with a sale");
        }
    }
} 