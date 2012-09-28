// -----------------------------------------------------------------------
// <copyright file="Customer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CQRSTest.WriteModel
{
    using CQRSTest.CQRS;
    using CQRSTest.CrossCutting.DomainEvents;
    using CQRSTest.Models.WriteModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Customer
        :
        IPublish<UserWantsToCreateCustomerFailed>,
        IPublish<CustomerCreatedByUser>,
        IPublish<UserWantsToChangeCustomerNameFailed>,
        IPublish<CustomerNameChangedByUser>,
        IPublish<UserWantsToRemoveCustomerFailed>,
        IPublish<CustomerRemovedByUser>
    {
        public void Handle(UserWantsToCreateCustomer @event)
        {
            if (!BusinessRule.CustomerMustNotAlreadyExist.IsSatisifedBy(this.State))
            {
                this.Publish(new UserWantsToCreateCustomerFailed { Name = @event.Name, Reason = "The customer already exists." });
                return;
            }

            if (!BusinessRule.NameMustBeAlphaNumeric.IsSatisifedBy(@event.Name))
            {
                this.Publish(
                    new UserWantsToCreateCustomerFailed
                        { Name = @event.Name, Reason = "The customer name is not valid." });
                return;
            }

            this.Publish(new CustomerCreatedByUser { CustomerId = this.Id, Name = @event.Name, });
        }

        public void Handle(UserWantsToChangeCustomerName @event)
        {
            if (!BusinessRule.CustomerMustExist.IsSatisifedBy(this.State))
            {
                this.Publish(new UserWantsToChangeCustomerNameFailed { Name = @event.Name, Reason = "The customer does not exists." });
            }

            if (!BusinessRule.NameMustBeAlphaNumeric.IsSatisifedBy(@event.Name))
            {
                this.Publish(
                    new UserWantsToChangeCustomerNameFailed
                        { Name = @event.Name, Reason = "The customer name is not valid." });
                return;
            }

            this.Publish(new CustomerNameChangedByUser { CustomerId = this.Id, Name = @event.Name, });
        }

        public void Handle(UserWantsToRemoveCustomer @event)
        {
            if (!BusinessRule.CustomerMustExist.IsSatisifedBy(this.State))
            {
                this.Publish(new UserWantsToRemoveCustomerFailed { Name = this.Name, Reason = "The customer does not exists." });
            }

            this.Publish(new CustomerRemovedByUser { CustomerId = this.Id });
        }
    }
}
