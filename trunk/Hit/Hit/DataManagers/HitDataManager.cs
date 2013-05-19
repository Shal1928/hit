using System;
using System.Collections.Generic;
using System.Linq;
using Hit.Models;

namespace Hit.DataManagers
{
    public class HitDataManager
    {
        private readonly HitsEntities _context;

        public HitDataManager()
        {
            _context = new HitsEntities();
        }

        //For all parameters
        public List<Requests> FindRequestsList(DateTime fromDate, DateTime toDate = default(DateTime))
        {
            fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 00, 00, 00);
            toDate = toDate == default(DateTime)
                     ? new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 23, 59, 59)
                     : new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);

            var q = from c in _context.Requests
                    where c.RequestDate >= fromDate && c.RequestDate <= toDate
                    select c;

            return q.ToList();
        }

        public Requests FindRequest(int requestId)
        {
            var q = from c in _context.Requests
                    where c.RequestId == requestId
                    select c;
            var customer = q.First();

            return customer;
        }

        //public void UpdateCustomer(Requests requests)
        //{
        //    _context.Attach(customer);
        //    //context.ObjectStateManager.GetObjectStateEntry(customer.EntityKey).SetModified();
        //    customer.SetAllModified(_context); // custom extension method

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (OptimisticConcurrencyException e)
        //    {
        //        //context.Refresh(RefreshMode.ClientWins, customer); // Last in wins
        //        //context.SaveChanges();
        //        throw (e);
        //    }
        //}

        public void AddRequests(Requests requests)
        {
            _context.AddToRequests(requests);
            _context.SaveChanges();
        }

        //public void DeleteCustomer(Customer customer)
        //{
        //    _context.Attach(customer);
        //    _context.DeleteObject(customer);
        //    _context.SaveChanges();
        //}

    }
}
