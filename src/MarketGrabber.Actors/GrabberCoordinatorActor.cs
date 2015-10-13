using Akka.Actor;
using Akka.Routing;

namespace MarketGrabber.Actors
{
    public class GrabberCoordinatorActor : ReceiveActor
    {
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
        }

        private void Working()
        {
            
        }
    }
}