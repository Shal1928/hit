namespace Hit.Stores.Base
{
    public interface IFileStore<T> : IStore<T>
    {
        string FileName
        {
            get;
            set;
        }
    }
}
