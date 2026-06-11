namespace Aleksandr.Live.Api.Domains
{
    public class Animal
    {
        public virtual string Name { get; set; }
        public virtual void Speak()
        {

        }

    }

    public class Dog : Animal
    {
        public new string Breed { get; set; }
        public override void Speak()
        {

        }

    }
}
