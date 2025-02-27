namespace PubSubSystem;

public class Publisher
{
    private readonly List<PubSubServer> _pubSubServers;
    public Publisher()
    {
        _pubSubServers = new List<PubSubServer>();
    }

    public void Register(PubSubServer pubSubServer)
    {
        _pubSubServers.Add(pubSubServer);
    }

    public void Unregister(PubSubServer pubSubServer)
    {
        _pubSubServers.Remove(pubSubServer);
    }

    public void Send(PubSubServer pubSubServer, Message message)
    {
        if (_pubSubServers.Contains(pubSubServer))
        {
            pubSubServer.Publish(message);
        }
        else 
            Console.WriteLine($"Error: No pub sub server registered for {pubSubServer}");
    }
}