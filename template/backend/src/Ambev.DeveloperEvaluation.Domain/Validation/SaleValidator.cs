using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for the Sale entity
    /// </summary>
    public class SaleValidator : AbstractValidator<Sale>
    {
        /// <summary>
        /// Constructor for the validator
        /// </summary>
        public SaleValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required");

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name is required")
                .MaximumLength(200)
                .WithMessage("Customer name cannot exceed 200 characters");

            RuleFor(x => x.BranchId)
                .NotEmpty()
                .WithMessage("Branch ID is required");

            RuleFor(x => x.BranchName)
                .NotEmpty()
                .WithMessage("Branch name is required")
                .MaximumLength(200)
                .WithMessage("Branch name cannot exceed 200 characters");

            RuleFor(x => x.TotalAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total amount cannot be negative");

            RuleFor(x => x.Items)
                .NotNull()
                .WithMessage("Items list cannot be null");

            RuleFor(x => x.Items.Count)
                .GreaterThan(0)
                .When(x => x.Status == Domain.Enums.SaleStatus.Completed)
                .WithMessage("A completed sale must have at least one item");
        }
    }
} 