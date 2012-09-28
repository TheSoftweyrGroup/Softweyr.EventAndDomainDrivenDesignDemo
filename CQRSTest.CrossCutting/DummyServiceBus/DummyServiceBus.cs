namespace CQRSTest
{
    /// <summary>
    /// Dummy class to be replaced by DummyServiceBus implementation.
    /// </summary>
    public static class DummyServiceBus
    {
        public static void Publish(object @event)
        {
            // Distribute to external services / domains outside this bounded context.
        }
    }
}