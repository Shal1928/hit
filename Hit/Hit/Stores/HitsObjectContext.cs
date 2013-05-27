using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Hit.Models;

namespace Hit.Stores
{
    public class HitsObjectContext : ObjectContext
    {
        public HitsObjectContext(): base("name=HitsEntities", "HitsEntities")
        {
            
            ContextOptions.ProxyCreationEnabled = false;
            ContextOptions.LazyLoadingEnabled = true;
            //HitsEntities.Requests
            try
            {
                _requests = CreateObjectSet<Requests>("Requests");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static readonly HitsObjectContext Instance = new HitsObjectContext();
        public static HitsObjectContext GetInstance()
        {
            return Instance;
        }

        //internal static HitsObjectContext Instance
        //{
        //    get
        //    {
        //        var ext = ContextContainer.Find<StoreContextExtension<CommonContext>>();

        //        if (ext == null)
        //        {
        //            ext = new StoreContextExtension<CommonContext> { ObjectContext = new CommonContext() };
        //            ContextContainer.Add(ext);
        //        }

        //        return ext.ObjectContext;
        //    }
        //}

        private ObjectSet<Requests> _requests = null;
        public ObjectSet<Requests> Requests
        {
            get
            {
                return _requests;
            }
        }
    }
}
