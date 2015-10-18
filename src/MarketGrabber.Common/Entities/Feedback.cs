namespace MarketGrabber.Common.Entities
{
    /// <summary>
    /// Class represents single feedback
    /// </summary>
    public class Feedback
    {
        public Feedback(int stars, string positive, string negative, string description)
        {
            this.Stars = stars;
            this.Positive = positive;
            this.Negative = negative;
            this.Description = description;
        }

        /// <summary>
        /// Stars count
        /// </summary>
        public int Stars { get; }

        /// <summary>
        /// Positive part of feedback
        /// </summary>
        public string Positive { get; }

        /// <summary>
        /// Negative part of feedback
        /// </summary>
        public string Negative { get; }

        /// <summary>
        /// Some users desciption
        /// </summary>
        public string Description { get; }
    }
}