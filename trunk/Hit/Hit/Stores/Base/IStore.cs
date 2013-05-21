namespace Hit.Stores.Base
{
    public interface IStore<T>
    {
        void Save(T storeObject);
        T Load();
    }
}
