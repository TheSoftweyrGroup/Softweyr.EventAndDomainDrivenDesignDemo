namespace CQRSTest
{
    using CQRSTest.CQRS;
    using CQRSTest.EventHandlers;
    using CQRSTest.WriteModel.Events;

    public static class EventAggregationConfig
    {
        public static void RegisterEventHandlers(DomainEventAggregationContext domainEventAggregator)
        {
            domainEventAggregator.RegisterEventHandlerImplicitly(new DummyServiceBusDomainEventHandler());

            // TODO: Move these into their own bounded contexts?
            domainEventAggregator.RegisterEventHandlerImplicitly(new CustomerManagementReadModelUpdater());
            domainEventAggregator.RegisterEventHandlerImplicitly(new CustomerManagementHtmlEventSourceUpdater());  
            domainEventAggregator.RegisterEventHandlerImplicitly(new CustomerEventsHandler(new EventStore())); 
        }
    }
}