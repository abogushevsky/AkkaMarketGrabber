using Akka.Actor;

namespace MarketGrabber.Actors
{
    public class GrabberCoordinatorActor : ReceiveActor
    {
        public GrabberCoordinatorActor()
        {
        }

        private void Waiting()
        {
            Receive<GrabberCommanderActor.AbleToAcceptJob>(job => Sender.Tell(new GrabberCommanderActor.CanAcceptJob(job.Url)));
        }
    }
}