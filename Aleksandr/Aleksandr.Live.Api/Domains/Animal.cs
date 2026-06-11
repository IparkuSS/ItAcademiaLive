namespace Aleksandr.Live.Api.Domains
{
    public class Animal
    {
        public Animal(string name)
        {
            Name = name;
        }
        private string Name { get; set; }
        public virtual void Speak()
        {

        }

    }
    public class Dog : Animal
    {
        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
        }
        private string Breed { get; set; }
        public override void Speak()
        {

        }
    }
}
