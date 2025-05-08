namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Locations service error.
    /// </summary>
    public class LocationsServiceExeption: Exception
    {
        /// <summary>
        /// Locations service error.
        /// </summary>
        /// <param name="message">Message.</param>
        public LocationsServiceExeption(string message) : base(message) { }

        /// <summary>
        /// Locations service error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public LocationsServiceExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
