namespace Matvey.Live.Api.Animals
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
            return $"{Name} makes a sound";
        }
    }
}
