namespace CQRSTest.CQRS
{
    public interface IHandleAllDomainEvents
    {
        void Handle<TType>(TType @event) where TType : IDomainEvent<TType>;
    }
}