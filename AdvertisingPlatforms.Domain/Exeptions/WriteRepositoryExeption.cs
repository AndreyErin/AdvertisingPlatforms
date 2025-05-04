namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Error writing to repository.
    /// </summary>
    public class WriteRepositoryExeption: Exception
    {
        /// <summary>
        /// Error writing to repository.
        /// </summary>
        /// <param name="message">Message.</param>
        public WriteRepositoryExeption(string message) : base(message) { }

        /// <summary>
        /// Error writing to repository.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public WriteRepositoryExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
