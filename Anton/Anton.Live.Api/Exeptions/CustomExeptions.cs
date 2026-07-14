namespace Anton.Live.Api.Exeptions
{
    public class EmptyNameException : Exception
    {
        public EmptyNameException()
            : base("Имя не может быть пустым") { }
    }

    public class InvalidAgeException : Exception
    {
        public int Age { get; }
        public InvalidAgeException(int age)
            : base($"Возраст {age} недопустим. Должен быть от 0 до 100.")
        {
            Age = age;
        }
    }

    public class InvalidEmailException : Exception
    {
        public string Email { get; }
        public InvalidEmailException(string email)
            : base($"Email '{email}' не содержит символ @.")
        {
            Email = email;
        }
    }

}
