using System.Xml.Linq;

namespace Aleksandr.Live.Api.Domains
{
    public class Animal
    {
        public Animal(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public virtual void Speak()
        {
            Console.WriteLine($"{Name} издает звук.");
        }

    }
    public class Dog : Animal
    {
        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
        }
        public string Breed { get; set; }
        public override void Speak()
        {
            Console.WriteLine($"{Name} породы {Breed} говорит: Гав-гав!");
        }
    }
}
