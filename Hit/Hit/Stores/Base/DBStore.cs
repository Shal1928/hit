using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Hit.Models.Base;

namespace Hit.Stores.Base
{
    public abstract class DBStore<T> : StoreBase<T> where T : UniqueObject
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
            return new EntityKey(EntitySetName, "ID", key);
        }

        #region Nested object persistence methods

        protected T GetObjectFromContext(int key)
        {
            return (T)ObjectContext.GetObjectByKey(CreateEntityKey(key));
        }

        /// <summary>
        /// Create UniqueObject from key and Persistents objects
        /// </summary>
        /// <param name="key">Key of required object</param>
        /// <param name="objectSet">Objects</param>
        /// <returns></returns>
        protected static UniqueObject GetObjectFromObjectSet(int key, IQueryable<UniqueObject> objectSet)
        {
            return objectSet.FirstOrDefault(item => item.Id == key);
        }

        /// <summary>
        /// Create UniqueObjects from key list and Persistents objects
        /// </summary>
        /// <param name="keys">Keys of required objects</param>
        /// <param name="objectSet">Objects</param>
        /// <returns></returns>
        protected static IEnumerable<UniqueObject> GetObjectsFromObjectSet(IEnumerable<int> keys, IQueryable<UniqueObject> objectSet)
        {
            if (keys == null) return Enumerable.Empty<UniqueObject>();

            return keys.Select(key => GetObjectFromObjectSet(key, objectSet));
        }

        #endregion
    }
}
