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
            public ParsePages(string content, MarketUrlTypes starsType) : base(content)
            {
                this.StarsType = starsType;
            }

            public MarketUrlTypes StarsType { get; }
        }

        public class ParseFeedbacks : ParseMessageBase
        {
            public ParseFeedbacks(string content, int stars) : base(content)
            {
                this.Stars = stars;
            }

            public int Stars { get; }
        }

        #endregion Messages
    }
}