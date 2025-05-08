namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Error reading from repository.
    /// </summary>
    public class ReadRepositoryExeption: Exception
    {
        /// <summary>
        /// Error reading from repository.
        /// </summary>
        /// <param name="message">Message.</param>
        public ReadRepositoryExeption(string message) : base(message) { }

        /// <summary>
        /// Error reading from repository.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public ReadRepositoryExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
