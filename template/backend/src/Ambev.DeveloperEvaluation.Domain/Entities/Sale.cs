using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Date and time of the sale
        /// </summary>
        [Required]
        public DateTime SaleDate { get; private set; }

        /// <summary>
        /// Customer ID
        /// </summary>
        [Required]
        public string CustomerId { get; private set; }

        /// <summary>
        /// Customer name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string CustomerName { get; private set; }

        /// <summary>
        /// Branch ID
        /// </summary>
        [Required]
        public string BranchId { get; private set; }

        /// <summary>
        /// Branch name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string BranchName { get; private set; }

        /// <summary>
        /// Total amount of the sale
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Sale status
        /// </summary>
        public SaleStatus Status { get; private set; }

        /// <summary>
        /// Sale items
        /// </summary>
        public virtual ICollection<SaleItem> Items { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected Sale()
        {
            Items = new List<SaleItem>();
            SaleDate = DateTime.UtcNow;
            Status = SaleStatus.Pending;
        }

      
    }
} 