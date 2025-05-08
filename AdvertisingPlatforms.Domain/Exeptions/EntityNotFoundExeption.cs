namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Entity not found in repository.
    /// </summary>
    public class EntityNotFoundExeption: Exception
    {
        /// <summary>
        /// Entity not found in repository.
        /// </summary>
        /// <param name="message">Message.</param>
        public EntityNotFoundExeption(string message) : base(message) { }

        /// <summary>
        /// Entity not found in repository.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerExeption">Inner error.</param>
        public EntityNotFoundExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
