namespace Aleksandr.Live
{
    public class InvalidPasswordException : Exception
    {
        public string InvalidPassword { get; }

        public InvalidPasswordException(string password, string message)
            : base(message)
        {
            InvalidPassword = password;
        }
    }
}
