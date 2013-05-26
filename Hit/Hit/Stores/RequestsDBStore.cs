using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Hit.Models;
using Hit.Stores.Base;

namespace Hit.Stores
{
    public class RequestsDBStore : DBStore<Requests>
    {
        ////HitsEntities.Requests
        public RequestsDBStore() : base("HitsEntities.Requests")
        {
            //
        }

        protected override ObjectContext ObjectContext
        {
            get
            {
                return HitsObjectContext2;
            }
        }

        protected HitsObjectContext HitsObjectContext2
        {
            get
            {
                return HitsObjectContext.GetInstance();
            }
        }

        protected override ObjectSet<Requests> GetObjectSet()
        {
            return HitsObjectContext2.Requests;
        }

        public override Requests LoadObject(int key)
        {
            return OnLoadObject(key);
        }

    } 
}
