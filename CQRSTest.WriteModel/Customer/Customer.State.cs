// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.State.cs" company="Collstream Ltd">
//   Copyright Collstream Ltd 2011
// </copyright>
// <summary>
//   Domain Aggregate representing a customer is the customer management domain.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CQRSTest.WriteModel
{
    using System;

    using CQRSTest.Models.WriteModel;

    /// <summary>
    /// Domain Aggregate representing a customer is the customer management domain.
    /// </summary>
    public partial class Customer
    {
        private CustomerState State;

        private Guid Id;

        private string Name;

        public void Apply(CustomerCreatedByUser @event)
        {
            this.State = CustomerState.Created;
            this.Name = @event.Name;
        }

        public void Apply(CustomerNameChangedByUser @event)
        {
            this.Name = @event.Name;
        }

        public void Apply(CustomerRemovedByUser @event)
        {
            this.State = CustomerState.Removed;
        }
    }
}
