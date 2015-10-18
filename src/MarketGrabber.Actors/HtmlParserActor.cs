using Akka.Actor;
using MarketGrabber.Actors.Messages;

namespace MarketGrabber.Actors
{
    public class HtmlParserActor : ReceiveActor
    {
        #region Messages

        public class ParseStarsGroups : ParseMessageBase
        {
            public ParseStarsGroups(string content) : base(content)
            {
            }
        }

        public class ParsePages : ParseMessageBase
        {
            public ParsePages(string content) : base(content)
            {
            }
        }

        public class ParseFeedbacks : ParseMessageBase
        {
            public ParseFeedbacks(string content) : base(content)
            {
            }
        }

        #endregion Messages
    }
}