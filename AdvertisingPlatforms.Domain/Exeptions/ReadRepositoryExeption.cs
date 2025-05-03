namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Error reading from repository.
    /// </summary>
    public class ReadRepositoryExeption: Exception
    {
        public ReadRepositoryExeption(string message) : base(message) { }                  
        public ReadRepositoryExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
