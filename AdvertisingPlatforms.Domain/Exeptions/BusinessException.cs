namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Custom error for this application.
    /// </summary>
    public class BusinessException: Exception
    {
        /// <summary>
        /// Custom error for this application.
        /// </summary>
        /// <param name="message">Message.</param>
        public BusinessException(string message) : base(message) { }

        /// <summary>
        /// Custom error for this application.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        public BusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
