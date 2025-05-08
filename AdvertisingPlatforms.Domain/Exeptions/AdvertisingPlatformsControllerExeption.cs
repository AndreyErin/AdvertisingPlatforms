namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Error in advertising platforms controller.
    /// </summary>
    public class AdvertisingPlatformsControllerExeption: Exception
    {
        /// <summary>
        /// Error in advertising platforms controller.
        /// </summary>
        /// <param name="message">Message.</param>
        public AdvertisingPlatformsControllerExeption(string message) : base(message) { }

        /// <summary>
        /// Error in advertising platforms controller.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public AdvertisingPlatformsControllerExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
