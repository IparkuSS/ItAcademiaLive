namespace Matvey.Live.Api.CustomException.Exceptions
{
    public class InvalidAgeException : Exception
    {
        public int InvalidAge { get; }

        public InvalidAgeException() : base("Возраст должен быть положительным.") { }

        public InvalidAgeException(int age, string message)
            : base($"{message} Возраст: {age}")
        {
            InvalidAge = age;
        }
    }
}
