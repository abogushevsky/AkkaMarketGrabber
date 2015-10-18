using System.Net.Http;
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

        public class DownloadUrlResult : MessageWithUrl
        {
            public DownloadUrlResult(MarketUrlTypes urlType, string content, string url) : base(url)
            {
                this.UrlType = urlType;
                this.Content = content;
            }

            public MarketUrlTypes UrlType { get; }

            public string Content { get; }
        }

        private class WebRequestResult : DownloadUrlResult
        {
            public WebRequestResult(MarketUrlTypes urlType, string content, string url, bool isSuccess) : base(urlType, content, url)
            {
                this.IsSuccess = isSuccess;
            }

            private bool IsSuccess { get; }
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
			    using (HttpClient httpClient = new HttpClient())
			    {
			        
			    }
			}
        }

        #endregion
    }
}