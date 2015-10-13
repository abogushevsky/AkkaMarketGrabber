using Akka.Actor;

namespace MarketGrabber.Actors
{
    public class GrabberCommanderActor : ReceiveActor, IWithUnboundedStash
    {
        #region Messages

        public class CanAcceptJob
        {
        }

        #endregion Messages

        #region Implementation of IActorStash

        /// <summary>
        /// Gets or sets the stash. This will be automatically populated by the framework AFTER the constructor has been run.
        ///             Implement this as an auto property.
        /// </summary>
        /// <value>
        /// The stash.
        /// </value>
        public IStash Stash { get; set; }

        #endregion
    }
}