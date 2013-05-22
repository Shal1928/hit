namespace Hit.Stores.Base
{
    public interface IStore<T> : IReadStore<T>
    {
        void Save(T storeObject);
    }

    public interface IReadStore<T>
    {
        T Load();
        T Load(int key);
    }
}
