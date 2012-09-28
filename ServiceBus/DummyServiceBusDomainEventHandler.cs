namespace CQRSTest
{
    using CQRSTest.CQRS;

    public class DummyServiceBusDomainEventHandler : IHandleAllDomainEvents
    {
        /// <summary>
        /// The generic handling of events.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="event"></param>
        public void Handle<TType>(TType @event) where TType : IDomainEvent<TType>
        {
            DummyServiceBus.Publish(@event);
        }
    }
}