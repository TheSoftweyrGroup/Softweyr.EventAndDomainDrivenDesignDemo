namespace CQRSTest.EventHandlers
{
    using System.Web.Script.Serialization;

    using CQRSTest.CQRS;
    using CQRSTest.Models;
    using CQRSTest.Models.ReadModel;
    using CQRSTest.Models.WriteModel;

    public class CustomerSummaryWebUpdateViewUpdater
        :
            IHandleDomainEvent<CustomerCreatedByUser>,
        IHandleDomainEvent<CustomerNameChangedByUser>,
        IHandleDomainEvent<CustomerRemovedByUser>
    {
        private readonly CustomerSummaryContext db = new CustomerSummaryContext();
        private readonly JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

        public void Handle(CustomerCreatedByUser @event)
        {
            db.CustomerSummaryWebUpdates.Add(new CustomerSummaryWebUpdate { Json = jsonSerializer.Serialize(@event) });
            db.SaveChanges();
        }

        public void Handle(CustomerNameChangedByUser @event)
        {
            db.CustomerSummaryWebUpdates.Add(new CustomerSummaryWebUpdate { Json = jsonSerializer.Serialize(@event) });
            db.SaveChanges();
        }

        public void Handle(CustomerRemovedByUser @event)
        {
            db.CustomerSummaryWebUpdates.Add(new CustomerSummaryWebUpdate { Json = jsonSerializer.Serialize(@event) });
            db.SaveChanges();
        }
    }
}