namespace PubSubSystem
{
    public class Progrma
    {
        public static void Main(string[] args)
        {
            //Define publisher
            var publisher1 = new Publisher();
            var publisher2 = new Publisher();
            
            //Define PubSubServer
            var pubSubServer1 = new PubSubServer();
            var pubSubServer2 = new PubSubServer();

            //Define Subscriber
            var subscriber1 = new Subscriber();
            var subscriber2 = new Subscriber();

            //Register Publishers to PubSubServers
            publisher1.Register(pubSubServer1);
            publisher2.Register(pubSubServer2);
            
            //Add Subscribers to the PubSubServers
            pubSubServer1.AddSubscriber(subscriber1);
            pubSubServer2.AddSubscriber(subscriber2);
            
            publisher1.Send(pubSubServer1, new Message("Header1","Message1 for Topic1"));
            publisher1.Send(pubSubServer2, new Message("Header2","Message2 for Topic1"));
            publisher2.Send(pubSubServer2, new Message("Header3","Message1 for Topic2"));

            // Unsubscribe from a topic
            pubSubServer1.RemoveSubscriber(subscriber2);

            // Publish more messages
            publisher1.Send(pubSubServer1, new Message("Header1","Message3 for Topic1"));
            publisher2.Send(pubSubServer2, new Message("Header2","Message2 for Topic2"));
        }
    }
}
