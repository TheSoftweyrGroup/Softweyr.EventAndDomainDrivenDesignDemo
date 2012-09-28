// -----------------------------------------------------------------------
// <copyright file="IPublish.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CQRSTest.CrossCutting.DomainEvents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CQRSTest.CQRS;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IPublish<TDomainEvent> : IPublish
    {
    }

    public interface IPublish
    {
    }

    public static class PublishExtensionMethods
    {
        public static void Publish<TDomainEvent>(this IPublish me, TDomainEvent domainEvent)
        {
            if (!(me is IPublish<TDomainEvent>))
            {
                throw new NotSupportedException(
                    string.Format(
                        "{0} has not been configured to publish events of type {1}",
                        me.GetType().FullName,
                        typeof(TDomainEvent).GetType()));
            }

            dynamic context = DomainEventAggregation.GlobalContext;
            context.Aggregate(domainEvent);
        }
    }
}
