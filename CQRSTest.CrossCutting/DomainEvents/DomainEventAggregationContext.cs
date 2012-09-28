namespace CQRSTest.CQRS
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class DomainEventAggregationContext
    {
        public ReaderWriterLockSlim genericEventHandlersLock = new ReaderWriterLockSlim();
        public List<IHandleAllDomainEvents> genericEventHandlers = new List<IHandleAllDomainEvents>();

        public System.Collections.Concurrent.ConcurrentDictionary<Type, List<object>> eventHandlerLists =
            new ConcurrentDictionary<Type, List<object>>();

        public void RegisterEventHandlerImplicitly(IHandleAllDomainEvents genericDomainEventHandler)
        {
            genericEventHandlersLock.EnterWriteLock();
            try
            {
                genericEventHandlers.Add(genericDomainEventHandler);
            }
            finally
            {
                genericEventHandlersLock.ExitWriteLock();
            }
        }

        public void RegisterEventHandlerImplicitly(object eventHandler)
        {
            foreach (var type in eventHandler.GetType().GetInterfaces().Where(
                contract => contract.GetGenericTypeDefinition() == typeof(IHandleDomainEvent<>)))
            {
                var eventHandlers = eventHandlerLists.GetOrAdd(type.GetGenericArguments()[0], (typeId) => new List<object> { });
                eventHandlers.Add(eventHandler);
            }
        }

        public void RegisterEventHandlerExplicitly<TType>(IHandleDomainEvent<TType> domainEventHandler)
            where TType : IDomainEvent<TType>
        {
            var eventHandlers = eventHandlerLists.GetOrAdd(typeof(TType), (type) => new List<object> { });
            eventHandlers.Add(domainEventHandler);
        }

        internal void Aggregate<TType>(IDomainEvent<TType> domainEvent)
            where TType : IDomainEvent<TType>
        {
            List<object> handlers;
            if (eventHandlerLists.TryGetValue(typeof(TType), out handlers))
            {
                foreach (var handler in handlers.Cast<IHandleDomainEvent<TType>>())
                {
                    dynamic dynHandler = handler;
                    dynHandler.Handle((TType)domainEvent);
                }

                genericEventHandlersLock.EnterReadLock();
                try
                {
                    foreach (var handler in genericEventHandlers)
                    {
                        dynamic dynHandler = handler;
                        dynHandler.Handle((TType)domainEvent);
                    }
                }
                finally
                {
                    genericEventHandlersLock.ExitReadLock();
                }
            }
        }
    }
}