namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// The data has been read, but it is not correct.
    /// </summary>
    public class InvalidFileDataExeption: Exception
    {
        /// <summary>
        /// The data has been read, but it is not correct.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidFileDataExeption(string message) : base(message) { }

        /// <summary>
        /// The data has been read, but it is not correct.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public InvalidFileDataExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
