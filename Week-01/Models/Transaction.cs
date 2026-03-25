using System;

namespace FirstBank.Core.Domain.Models
{
    /// <summary>
    /// Represents a money transfer transaction between two accounts.
    /// </summary>
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public Guid SourceAccountId { get; set; }

        public Guid DestinationAccountId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}