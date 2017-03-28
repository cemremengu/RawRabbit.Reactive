namespace RawRabbit.Reactive
{
    using System;

    public static class RawRabbitReactiveExtensions
    {
        public static IObservable<T> CreateSubscriptionObservable<T>(this IBusClient busClient) where T : class
        {
            return new RawRabbitSubscriptionObservable<T>(busClient);
        }
    }
}
