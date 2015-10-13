using System.Runtime.CompilerServices;
using Akka.Actor;
using MarketGrabber.Actors.Messages;

namespace MarketGrabber.Actors
{
    public class GrabberCommanderActor : ReceiveActor, IWithUnboundedStash
    {
        #region Messages

        public class CanAcceptJob : MessageWithUrl
        {
            public CanAcceptJob(string url) : base (url)
            {
            }
        }

        public class AbleToAcceptJob : MessageWithUrl
        {
            public AbleToAcceptJob(string url) : base(url)
            {
            }
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