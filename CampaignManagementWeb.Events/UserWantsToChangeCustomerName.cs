using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRSTest.Models.WriteModel
{
    using System.ComponentModel.DataAnnotations;

    using CQRSTest.CQRS;

    public class UserWantsToChangeCustomerName : IDomainEvent<UserWantsToChangeCustomerName>
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
    }
}