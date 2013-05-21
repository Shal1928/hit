using System;

namespace Hit.Stores.Base
{
    public abstract class StoreBase<T> : IStore<T>
    {
        public virtual void Save(T storeObject)
        {
            throw new NotImplementedException();
        }

        public virtual T Load()
        {
            throw new NotImplementedException();
        }
    }
}
