namespace MarketGrabber.Common.Entities
{
    /// <summary>
    /// Class represents information about shop at the market
    /// </summary>
    public class Shop
    {
        public Shop(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Shop unique id
        /// </summary>
        public string Id { get; }
        
        /// <summary>
        /// Shop name
        /// </summary>
        public string Name { get; } 
    }
}