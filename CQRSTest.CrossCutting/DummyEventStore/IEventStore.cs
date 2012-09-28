namespace CQRSTest.WriteModel.Events
{
    using System;
    using System.Collections.Generic;

    public interface IEventStore
    {
        IEnumerable<object> GetEventsFor(Guid id);

        void Store(Guid customerId, object @event);
    }
}