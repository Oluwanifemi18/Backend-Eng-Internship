using System;
using System.Collections.Generic;
using FirstBank.Core.Domain.Models;
using FirstBank.Core.Domain.Validation;

class Program
{
    static void Main()
    {
        var account1 = new BankAccount
        {
            AccountId = Guid.NewGuid(),
            AccountHolderName = "Alice",
            Balance = 2500000
        };

        var account2 = new BankAccount
        {
            AccountId = Guid.NewGuid(),
            AccountHolderName = "Bob",
            Balance = 300000
        };

        var accounts = new Dictionary<Guid, BankAccount>
        {
            { account1.AccountId, account1 },
            { account2.AccountId, account2 }
        };

        var validator = new TransactionValidator(accounts);

        // VALID TRANSACTION
        var validTransaction = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            SourceAccountId = account1.AccountId,
            DestinationAccountId = account2.AccountId,
            Amount = 7000,
            Timestamp = DateTime.Now,
            Description = "Normal transfer"
        };

        var result1 = validator.Validate(validTransaction);
        Console.WriteLine($"Valid Transaction Result: {result1.IsValid}");

        // INVALID TRANSACTION (negative amount)
        var invalidTransaction = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            SourceAccountId = account1.AccountId,
            DestinationAccountId = account2.AccountId,
            Amount = -50,
            Timestamp = DateTime.Now,
            Description = "Invalid transfer"
        };

        var result2 = validator.Validate(invalidTransaction);
        Console.WriteLine($"Invalid Transaction Result: {result2.IsValid}");

        // LARGE TRANSACTION
        var largeTransaction = new Transaction
        {
            TransactionId = Guid.NewGuid(),
            SourceAccountId = account1.AccountId,
            DestinationAccountId = account2.AccountId,
            Amount = 200000,
            Timestamp = DateTime.Now,
            Description = "Large transfer"
        };

        var result3 = validator.Validate(largeTransaction);
        Console.WriteLine($"Large Transaction Result: {result3.IsValid}");
    }
}