namespace Anton.Live.Api.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public virtual string Speak()
        {
            return $"Звук...";
        }
    }

    public class Cat : Animal
    {
        public string Color { get; set; }

        public Cat(string Name, string color) : base(Name)
        {
            Color = color;
        }
        public override string Speak()
        {
            return $"{Name} цвета {Color} говорит Мяу";
        }
    }
}

