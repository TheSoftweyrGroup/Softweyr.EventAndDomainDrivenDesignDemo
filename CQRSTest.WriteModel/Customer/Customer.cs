// -----------------------------------------------------------------------
// <copyright file="Customer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CQRSTest.WriteModel
{
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Customer
    {
        public Customer(Guid customerId)
        {
            this.Id = customerId;
        }
    }
}
