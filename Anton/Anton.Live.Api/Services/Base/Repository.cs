namespace Anton.Live.Api.Services.Base
{
    public abstract class Repository
    {
        protected int NextId<T>(List<T> items)
        {
            return items.Count + 1;
        }
    }
}