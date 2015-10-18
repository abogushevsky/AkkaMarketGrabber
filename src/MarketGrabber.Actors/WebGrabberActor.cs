using System;
using System.Net.Http;
using Akka.Actor;
using MarketGrabber.Actors.Messages;

namespace MarketGrabber.Actors
{
    public class WebGrabberActor : ReceiveActor
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

        public class DownloadFailedResult : MessageWithUrl 
        {
            public DownloadFailedResult(MarketUrlTypes urlType, string url) : base(url)
            {
                this.UrlType = urlType;
            }

            public MarketUrlTypes UrlType { get; }
        }

        private class WebRequestResult : DownloadUrlResult
        {
            public WebRequestResult(MarketUrlTypes urlType, string content, string url, bool isSuccess) : base(urlType, content, url)
            {
                this.IsSuccess = isSuccess;
            }

            public bool IsSuccess { get; }
        }

        private readonly HttpClient httpClient;

        public WebGrabberActor()
        {
            this.httpClient = new HttpClient();
            Initialize();
        }
        
        private void Initialize()
        {
            Receive<DownloadUrl>(msg =>
            {
                this.httpClient.GetStringAsync(msg.Url).ContinueWith(task =>
                {
                    try
                    {
                        return new WebRequestResult(msg.UrlType, task.Result, msg.Url, true);
                    }
                    catch (Exception)
                    {
                        return new WebRequestResult(msg.UrlType, null, msg.Url, false);
                    }
                }).PipeTo(Self);
            });

            Receive<WebRequestResult>(msg =>
            {
                if (msg.IsSuccess) Context.Parent.Tell(new DownloadUrlResult(msg.UrlType, msg.Content, msg.Url));
                else Context.Parent.Tell(new DownloadFailedResult(msg.UrlType, msg.Url));
            });
        }

        protected override void PostStop()
        {
            this.httpClient.Dispose();
            base.PostStop();
        }
    }
}