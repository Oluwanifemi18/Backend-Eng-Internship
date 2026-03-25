using System;
using System.Collections.Generic;
using FirstBank.Core.Domain.Interfaces;
using FirstBank.Core.Domain.Models;
using FirstBank.Core.Domain.Results;

namespace FirstBank.Core.Domain.Validation
{
    /// <summary>
    /// Validates transaction rules for FirstBank.
    /// </summary>
    public class TransactionValidator : IValidator<Transaction>
    {
        private readonly Dictionary<Guid, BankAccount> _accounts;

        public TransactionValidator(Dictionary<Guid, BankAccount> accounts)
        {
            _accounts = accounts;
        }

        public ValidationResult Validate(Transaction transaction)
        {
            var result = new ValidationResult();
            result.IsValid = true;

            // Rule 1: Amount > 0
            if (transaction.Amount <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Amount must be greater than 0.");
            }

            // Rule 2: Accounts cannot be the same
            if (transaction.SourceAccountId == transaction.DestinationAccountId)
            {
                result.IsValid = false;
                result.Errors.Add("Source and destination accounts cannot be the same.");
            }

            // Rule 3: Source account must exist
            if (!_accounts.ContainsKey(transaction.SourceAccountId))
            {
                result.IsValid = false;
                result.Errors.Add("Source account does not exist.");
            }

            // Rule 4: Large transaction warning
            if (transaction.Amount > 150000)
            {
                Console.WriteLine(" WARNING!!: Transaction exceeds ₦150,000, It is a large transaction.");
            }

            return result;
        }
    }
}