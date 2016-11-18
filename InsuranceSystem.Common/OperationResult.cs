namespace InsuranceSystem.Common
{
    /// <summary>
    /// Provides  a success flag and message
    /// useful as a method return type.
    /// </summary>
    public class OperationResult
    {
        public OperationResult()
        {

        }
        public OperationResult(bool success, string message) :this()
        {
            this.Succes = success;
            this.Message = message;
        }

        public bool Succes { get; set; }
        public string Message { get; set; }

    }
}
