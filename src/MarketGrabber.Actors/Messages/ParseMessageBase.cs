namespace MarketGrabber.Actors.Messages
{
    public abstract class ParseMessageBase
    {
        public ParseMessageBase(string content)
        {
            this.Content = content;
        }

        public string Content { get; } 
    }
}