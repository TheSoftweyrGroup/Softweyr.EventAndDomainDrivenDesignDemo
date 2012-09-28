using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRSTest.EventHandlers
{
    using CQRSTest.CQRS;
    using CQRSTest.Models;
    using CQRSTest.Models.ReadModel;
    using CQRSTest.Models.WriteModel;

    public class CustomerSummaryViewUpdater
        :
        IHandleDomainEvent<CustomerCreatedByUser>,
        IHandleDomainEvent<CustomerNameChangedByUser>,
        IHandleDomainEvent<CustomerRemovedByUser>
    {
        private CustomerSummaryContext db = new CustomerSummaryContext();

        public void Handle(CustomerCreatedByUser @event)
        {
            db.CustomerSummaries.Add(new CustomerSummary { CustomerId = @event.CustomerId, Name = @event.Name });
            db.SaveChanges();
        }

        public void Handle(CustomerNameChangedByUser @event)
        {
            var customerSummary = db.CustomerSummaries.Find(@event.CustomerId);
            customerSummary.Name = @event.Name;
            db.SaveChanges();
        }

        public void Handle(CustomerRemovedByUser @event)
        {
            var customerSummary = db.CustomerSummaries.Find(@event.CustomerId);
            db.CustomerSummaries.Remove(customerSummary);
            db.SaveChanges();
        }
    }
}