namespace CQRSTest.Models.WriteModel
{
    using CQRSTest.CQRS;

    public class UserWantsToRemoveCustomerFailed : IDomainEvent<UserWantsToRemoveCustomerFailed>
    {
        public string Name { get; set; }

        public string Reason { get; set; }
    }
}