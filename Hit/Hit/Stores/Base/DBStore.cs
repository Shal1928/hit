using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Diagnostics;
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

        
        public virtual T SaveObject(T obj)
        {
            //ValidateObject(obj);

            try
            {
                var result = OnSaveObject(SecurityCheckObject(obj));
                OnApplyContextChanges();
                return result;
            }
            catch (UpdateException ex)
            {
                var message = string.Format("Update error while saving an object with key {0}.", obj.Id);

                message += Environment.NewLine + ex.Message;

                if (ex.InnerException != null) message += Environment.NewLine + ex.InnerException.Message;
                
                throw new Exception(message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Cannot save object with key {0}.\n{1}", obj.Id, ex.Message), ex);
            }
        }

        public virtual IList<T> SaveObjects(IEnumerable<T> objects)
        {
            //foreach (T obj in objects)
            //{
            //    ValidateObject(obj);
            //}

            var enumerable = objects as List<T> ?? objects.ToList();
            
            try
            {
                var savedObjects = SecurityCheckObjects(enumerable).Select(OnSaveObject).ToList();
                OnApplyContextChanges();
                return savedObjects;
            }
            catch (UpdateException ex)
            {
                var message = string.Format("Update error while saving an object with keys {0}.", string.Join(", ", enumerable.Select(obj => obj.Id)));

                if (ex.InnerException != null)
                {
                    message += Environment.NewLine + ex.InnerException.Message;
                }

                throw new Exception(message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Cannot save objects with keys {0}.\n{1}", string.Join(", ", enumerable.Select(obj => obj.Id)), ex.Message), ex);
            }
        }

        protected virtual T OnSaveObject(T newObject)
        {
            T savedObject;

            if (newObject.IsNew)
            {
                ObjectContext.AddObject(EntitySetName, newObject);

                savedObject = newObject;
            }
            else
            {
                //var oldObject = ObjectContext.GetObjectByKey(CreateEntityKey(newObject.Id));
                savedObject = ObjectContext.ApplyCurrentValues(EntitySetName, newObject);
                //savedObject = ObjectContext.ApplyCurrentValues(EntitySetName, newObject);

                //savedObject = SaveChildrenObjects(newObject.IsNew, savedObject, newObject);
            }

            return savedObject;
        }

        public virtual T LoadObject(int key)
        {
            try
            {
                return SecurityCheckObject(OnLoadObject(key));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Cannot load object with specified key {0}.\n{1}", key, ex.Message), ex);
            }
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

        protected virtual T SecurityCheckObject(T obj)
        {
            throw new NotImplementedException("SecurityCheckObject is not implemented!");
        }

        private IEnumerable<T> SecurityCheckObjects(IEnumerable<T> objects)
        {
            throw new NotImplementedException("SecurityCheckObjects is not implemented!");
        }


        public int DeleteObject(int key)
        {
            try
            {
                var result = OnDeleteObject(key);
                ObjectContext.SaveChanges();
                return result.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Cannot delete object with key {0}.\n{1}", key, ex.Message), ex);
            }
        }

        /// <summary>
        /// Deletes objects of type <typeparamref name="T" />
        /// </summary>
        public IList<int> DeleteObjects(IEnumerable<int> keys)
        {
            throw new NotImplementedException();

            //IEnumerable<ObjectKey> deletedObjectsKeys;

            //using (var tScope = new TransactionScope())
            //{
            //    deletedObjectsKeys = keys.Select(DeleteObject).ToList();

            //    tScope.Complete();
            //}

            //return deletedObjectsKeys.ToList();
        }

        protected virtual T OnDeleteObject(int key)
        {
            var obj = SecurityCheckObject((T)ObjectContext.GetObjectByKey(CreateEntityKey(key)));

            //if (obj is ILockableObject && ((ILockableObject)obj).IsLocked)
            //{
            //    throw new Exception("object is locked");
            //}

            //DeleteChildrenObjects(obj);

            ObjectContext.DeleteObject(obj);

            return obj;
        }
    }
}
