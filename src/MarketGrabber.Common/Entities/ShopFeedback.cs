namespace MarketGrabber.Common.Entities
{
    /// <summary>
    /// Class represents single feedback for shop
    /// </summary>
    public class ShopFeedback : Feedback
    {
        public ShopFeedback(Shop shop, Feedback feedback)
            : this(shop, feedback.Stars, feedback.Positive, feedback.Negative, feedback.Description)
        {
            
        }

        public ShopFeedback(Shop shop, int stars, string positive, string negative, string description) 
            : base(stars, positive, negative, description)
        {
            this.Shop = shop;
        }

        /// <summary>
        /// The store whitch feedback was written for
        /// </summary>
        public Shop Shop { get; }
    }
}