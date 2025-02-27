namespace PubSubSystem;

public class Message
{
    public string Header { get;}
    public string Content {get;}

    public Message(string header, string content)
    {
        Header = header;
        Content = content;
    }
}