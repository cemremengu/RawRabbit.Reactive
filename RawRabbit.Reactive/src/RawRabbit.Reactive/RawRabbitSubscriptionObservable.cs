namespace RawRabbit.Reactive
{
    using System;
    using System.Reactive.Disposables;
    using System.Threading.Tasks;

    public class RawRabbitSubscriptionObservable<T> : IObservable<T> where T : class
    {
        private readonly IBusClient _busClient;
        private IObserver<T> _observer;

        protected internal RawRabbitSubscriptionObservable(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observer = observer;

            try
            {
                _busClient.SubscribeAsync<T>(message => { return Task.Run(() => _observer.OnNext(message)); });
            }
            catch (Exception e)
            {
                _observer.OnError(e);
            }

            return Disposable.Empty;
        }
    }
}
