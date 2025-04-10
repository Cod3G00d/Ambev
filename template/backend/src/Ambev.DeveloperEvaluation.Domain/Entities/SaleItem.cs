using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale item
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Product ID
        /// </summary>
        [Required]
        public string ProductId { get; private set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ProductName { get; private set; }

        /// <summary>
        /// Quantity sold
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; private set; }

        /// <summary>
        /// Unit price of the product
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero")]
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Discount applied to the item
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Discount cannot be negative")]
        public decimal Discount { get; private set; }

        /// <summary>
        /// Total amount of the item ((UnitPrice * Quantity) - Discount)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalItemAmount { get; private set; }

        /// <summary>
        /// Related sale
        /// </summary>
        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected SaleItem()
        {
        }
    }
} 