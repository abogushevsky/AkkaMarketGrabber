using Akka.Actor;

namespace MarketGrabber.Actors
{
    public class WebGrabberActor : UntypedActor
    {
		public class DownloadUrl 
		{
			public DownloadUrl(string url) 
			{
				this.Url = url;
			}

			public string Url { get; }
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