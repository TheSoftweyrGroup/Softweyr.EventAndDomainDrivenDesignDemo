// -----------------------------------------------------------------------
// <copyright file="IHandleDomainEvent.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CQRSTest.CQRS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IHandleDomainEvent<TEvent>
        where TEvent : IDomainEvent<TEvent>
    {
        void Handle(TEvent @event);
    }
}
