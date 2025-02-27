using System.Collections.Concurrent;

namespace PubSubSystem;

public class PubSubServer
{
    private readonly ConcurrentBag<Subscriber> _subscribers;
    public PubSubServer()
    {
        _subscribers = new ConcurrentBag<Subscriber>();
    }

    public void AddSubscriber(Subscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(Subscriber subscriber)
    {
        _subscribers.TryTake(out subscriber);
    }

    public void Publish(Message message)
    {
        foreach (var subscribers in _subscribers)
        {
            subscribers.TakeMessage(message);
        }
    }
}