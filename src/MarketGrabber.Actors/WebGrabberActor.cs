using Akka.Actor;
using MarketGrabber.Actors.Messages;

namespace MarketGrabber.Actors
{
    public class WebGrabberActor : UntypedActor
    {
		public class DownloadUrl : MessageWithUrl
		{
			public DownloadUrl(string url, MarketUrlTypes urlType) : base(url)
			{
                this.UrlType = urlType;
			}

            public MarketUrlTypes UrlType { get; }
		}
			
        #region Overrides of UntypedActor

        /// <summary>
        /// To be implemented by concrete UntypedActor, this defines the behavior of the UntypedActor.
        ///             This method is called for every message received by the actor.
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void OnReceive(object message)
        {
			if (message is DownloadUrl) 
			{
			}
        }

        #endregion
    }
}