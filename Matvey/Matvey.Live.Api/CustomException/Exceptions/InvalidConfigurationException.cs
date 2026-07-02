namespace Matvey.Live.Api.CustomException.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public string ConfigKey { get; }
        public string ConfigValue { get; }

        public InvalidConfigurationException()
            : base("Некорректная конфигурация.") { }

        public InvalidConfigurationException(string key, string value, string message)
            : base($"Параметр '{key}' = '{value}'. {message}")
        {
            ConfigKey = key;
            ConfigValue = value;
        }
    }
}
