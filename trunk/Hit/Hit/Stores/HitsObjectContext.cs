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
        private HitsObjectContext() : base("name=HitsEntities", "HitsEntities")
        {
            ContextOptions.ProxyCreationEnabled = false;

            //HitsEntities.Requests
            try
            {
                _requests = CreateObjectSet<Requests>("Requests");
            }
            catch (Exception e)
            {
                
                throw;
            }
            
        }

        private static readonly HitsObjectContext Instance = new HitsObjectContext();
        public static HitsObjectContext GetInstance()
        {
            return Instance;
        }

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
