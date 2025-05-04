namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Advertising platforms service error.
    /// </summary>
    public class AdvertisingPlatformsServiceExeption: Exception
    {
        /// <summary>
        /// Advertising platforms service error.
        /// </summary>
        /// <param name="message">Message.</param>
        public AdvertisingPlatformsServiceExeption(string message) : base(message) { }

        /// <summary>
        /// Advertising platforms service error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public AdvertisingPlatformsServiceExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
