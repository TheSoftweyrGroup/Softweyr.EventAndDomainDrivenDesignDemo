// -----------------------------------------------------------------------
// <copyright file="CustomerEventsHandler.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CQRSTest.WriteModel.Events
{
    using System;
    using System.Linq;
    using System.Text;

    using CQRSTest.CQRS;
    using CQRSTest.Models.WriteModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomerEventsHandler
        :
        IHandleDomainEvent<UserWantsToCreateCustomer>,
        IHandleDomainEvent<CustomerCreatedByUser>,
        IHandleDomainEvent<UserWantsToChangeCustomerName>,
        IHandleDomainEvent<CustomerNameChangedByUser>,
        IHandleDomainEvent<UserWantsToRemoveCustomer>,
        IHandleDomainEvent<CustomerRemovedByUser>
    {
        private readonly IEventStore eventStore;

        public CustomerEventsHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        #region Events to process

        public void Handle(UserWantsToCreateCustomer @event)
        {
            Handle(Guid.NewGuid(), @event);
        }

        public void Handle(UserWantsToChangeCustomerName @event)
        {
            Handle(@event.CustomerId, @event);
        }

        public void Handle(UserWantsToRemoveCustomer @event)
        {
            Handle(@event.CustomerId, @event);
        }

        #endregion

        #region Events To Persist

        public void Handle(CustomerCreatedByUser @event)
        {
            this.eventStore.Store(@event.CustomerId, @event);
        }

        public void Handle(CustomerNameChangedByUser @event)
        {
            this.eventStore.Store(@event.CustomerId, @event);
        }

        public void Handle(CustomerRemovedByUser @event)
        {
            this.eventStore.Store(@event.CustomerId, @event);
        }

        #endregion

        #region Re-usable methods

        private void Handle<TType>(Guid customerId, TType @event)
        {
            dynamic customer = new Customer(customerId);
            foreach (dynamic customerEvent in this.eventStore.GetEventsFor(customerId))
            {
                customer.Apply(customerEvent);
            }

            customer.Handle(@event);
        }

        #endregion
    }
}
