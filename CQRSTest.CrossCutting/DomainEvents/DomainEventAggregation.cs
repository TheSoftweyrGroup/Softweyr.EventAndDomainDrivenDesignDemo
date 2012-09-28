namespace CQRSTest.CQRS
{
    public static class DomainEventAggregation
    {
        private static readonly DomainEventAggregationContext globalContext = new DomainEventAggregationContext();

        public static DomainEventAggregationContext GlobalContext
        {
            get
            {
                return globalContext;
            }
        }
    }
}