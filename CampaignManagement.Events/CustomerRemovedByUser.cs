namespace CQRSTest.Models.WriteModel
{
    using System;

    using CQRSTest.CQRS;

    public class CustomerRemovedByUser : IDomainEvent<CustomerRemovedByUser>
    {
        public Guid CustomerId { get; set; }
    }
}