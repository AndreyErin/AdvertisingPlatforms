namespace AdvertisingPlatforms.Domain.Exeptions
{
    /// <summary>
    /// Entity not found in repository.
    /// </summary>
    public class EntityNotFoundExeption: Exception
    {
        public EntityNotFoundExeption(string message) : base(message) { }                  
        public EntityNotFoundExeption(string message, Exception innerExeption) : base(message, innerExeption) { }
    }
}
