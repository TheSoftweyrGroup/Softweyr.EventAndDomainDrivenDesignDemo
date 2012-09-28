namespace CQRSTest.Models.WriteModel
{
    using System;

    using CQRSTest.CQRS;

    public class CustomerNameChangedByUser : IDomainEvent<CustomerNameChangedByUser>
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
    }
}