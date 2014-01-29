using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRSTest.Models.WriteModel
{
    using System.ComponentModel.DataAnnotations;

    using CQRSTest.CQRS;

    public class UserWantsToCreateCustomer : IDomainEvent<UserWantsToCreateCustomer>
    {
        public string Name { get; set; }
    }
}