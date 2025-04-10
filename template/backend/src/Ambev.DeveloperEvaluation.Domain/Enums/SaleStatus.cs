namespace Ambev.DeveloperEvaluation.Domain.Enums
{
    /// <summary>
    /// Represents the possible states of a sale
    /// </summary>
    public enum SaleStatus
    {
        /// <summary>
        /// Sale is pending
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Sale is completed
        /// </summary>
        Completed = 1,

        /// <summary>
        /// Sale is cancelled
        /// </summary>
        Cancelled = 2
    }
} 