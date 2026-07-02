namespace Matvey.Live.Api.CustomException.Exceptions
{
    public class MaxRetryExceededException : Exception
    {
        public string OperationName { get; }
        public int MaxRetries { get; }

        public MaxRetryExceededException()
            : base("Превышен лимит попыток.") { }

        public MaxRetryExceededException(string opName, int maxRetries)
            : base($"Операция '{opName}' не удалась после {maxRetries} попыток.")
        {
            OperationName = opName;
            MaxRetries = maxRetries;
        }
    }
}
