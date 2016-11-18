namespace InsuranceSystem.BLL.Infrastructure
{
    using System;

    public class ValidationException : Exception
    {
        public string Property { get; }
        public ValidationException(string message, string property) : base(message)
        {
            this.Property = property;
        }
    }
}
