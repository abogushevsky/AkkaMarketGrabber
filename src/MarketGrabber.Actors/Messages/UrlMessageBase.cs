using Microsoft.SqlServer.Server;

namespace MarketGrabber.Actors.Messages
{
    public abstract class MessageWithUrl
    {
        protected MessageWithUrl(string url)
        {
            this.Url = url;
        }

         public string Url { get; }
    }
}