namespace Matvey.Live.Api.Animals
{
    public class Dog : Animal
    {
        public string Breed { get; set; }

        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
        }

        public override string Speak()
        {
            return $"{Name} says: Woof! Woof!";
        }
    }
}
