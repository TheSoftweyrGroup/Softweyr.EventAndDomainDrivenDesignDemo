namespace CQRSTest.Models.WriteModel
{
    using CQRSTest.CQRS;

    public class UserWantsToChangeCustomerNameFailed : IDomainEvent<UserWantsToChangeCustomerNameFailed>
    {
        public string Name { get; set; }

        public string Reason { get; set; }
    }
}