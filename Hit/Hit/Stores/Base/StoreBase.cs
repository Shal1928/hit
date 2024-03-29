﻿using System;

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

        public T Load(int key)
        {
            throw new NotImplementedException();
        }
    }
}
