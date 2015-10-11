using Akka.Actor;

namespace MarketGrabber.Actors
{
    public class WebGrabberActor : UntypedActor
    {
        #region Overrides of UntypedActor

        /// <summary>
        /// To be implemented by concrete UntypedActor, this defines the behavior of the UntypedActor.
        ///             This method is called for every message received by the actor.
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void OnReceive(object message)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}