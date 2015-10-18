using System;
using Akka.Actor;
using Akka.Routing;
using MarketGrabber.Actors.Messages;

namespace MarketGrabber.Actors
{
    public class GrabberCoordinatorActor : ReceiveActor
    {
		#region Messages 

		public class BeginJob : MessageWithUrl 
		{
			public BeginJob(string url) : base(url) 
			{
			}
		}        

		#endregion Messages
        private IActorRef downloaderActor;
        private IActorRef parserActor;

        public GrabberCoordinatorActor()
        {
            Waiting();
        }

        protected override void PreStart()
        {
            this.downloaderActor =
                Context.ActorOf(Props.Create(() => new WebGrabberActor()).WithRouter(new SmallestMailboxPool(10)));
            this.parserActor =
                Context.ActorOf(Props.Create(() => new HtmlParserActor()).WithRouter(new RoundRobinPool(10)));
        }

        private void BecomeWorking()
        {
            Become(Working);
        }

        private void BecomeWaiting()
        {
            Become(Waiting);
        }

        private void Waiting()
        {
            Receive<GrabberCommanderActor.AbleToAcceptJob>(job => Sender.Tell(new GrabberCommanderActor.CanAcceptJob(job.Url)));
			Receive<BeginJob> (job => 
			{
				BecomeWorking();
				this.downloaderActor.Tell(new WebGrabberActor.DownloadUrl(job.Url, MarketUrlTypes.MainPage));
			});
        }

        private void Working()
        {
            Receive<WebGrabberActor.DownloadUrlResult>(page =>
            {
                switch (page.UrlType)
                {
                    case MarketUrlTypes.MainPage:
                        this.parserActor.Tell(new HtmlParserActor.ParseStarsGroups(page.Content));
                        break;
                    case MarketUrlTypes.StarsGroupPage:
                        this.parserActor.Tell(new HtmlParserActor.ParsePages(page.Content, page.UrlType));
                        break;
                    case MarketUrlTypes.FiveStarPage:
                    case MarketUrlTypes.FourStarPage:
                    case MarketUrlTypes.ThreeStarPage:
                    case MarketUrlTypes.TwoStarPage:
                    case MarketUrlTypes.OneStarPage:

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }
    }
}