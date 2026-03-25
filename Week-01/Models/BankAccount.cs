using System;

namespace FirstBank.Core.Domain.Models
{
    /// <summary>
    /// Represents a bank account in the FirstBank domain model.
    /// </summary>
    public class BankAccount
    {
        public Guid AccountId { get; set; }

        public string AccountHolderName { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public string CurrencyCode { get; set; } = "NGN";

        public bool IsActive { get; set; }
    }
}