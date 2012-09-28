namespace CQRSTest.Models.WriteModel
{
    using CQRSTest.CQRS;

    /// <summary>
    /// </summary>
    public class UserWantsToCreateCustomerFailed : IDomainEvent<UserWantsToCreateCustomerFailed>
    {
        public string Name { get; set; }

        public string Reason { get; set; }
    }
}