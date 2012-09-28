namespace CQRSTest.Models.WriteModel
{
    using System;

    using CQRSTest.CQRS;

    /// <summary>
    /// </summary>
    public class CustomerCreatedByUser : IDomainEvent<CustomerCreatedByUser>
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
    }
}