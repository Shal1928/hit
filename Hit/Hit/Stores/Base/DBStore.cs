using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Hit.Models.Base;

namespace Hit.Stores.Base
{
    public abstract class DBStore<T> : StoreBase<T> where T: DataObject
    {
        protected DBStore(string entitySetName)
        {
            EntitySetName = entitySetName;
        }

        protected readonly string EntitySetName;

        protected abstract ObjectContext ObjectContext
        {
            get;
        }

        protected abstract ObjectSet<T> GetObjectSet();

        protected virtual void OnApplyContextChanges()
        {
            ObjectContext.SaveChanges();
        }

        protected virtual T OnLoadObject(int key)
        {
            return (T)ObjectContext.GetObjectByKey(CreateEntityKey(key));
        }

        protected EntityKey CreateEntityKey(int key)
        {
            return new EntityKey(EntitySetName, EnumerableEx.Return(new KeyValuePair<string, object>("ID", key)));
        }
    }
}
