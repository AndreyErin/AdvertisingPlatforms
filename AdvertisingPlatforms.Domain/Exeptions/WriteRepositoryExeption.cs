namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Error writing to repository.
    /// </summary>
    public class WriteRepositoryExeption: Exception
    {
        public WriteRepositoryExeption(string message) : base(message) { }                  
        public WriteRepositoryExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
