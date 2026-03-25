using System.Collections.Generic;

namespace FirstBank.Core.Domain.Results
{
    /// <summary>
    /// Represents the outcome of a validation process.
    /// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}