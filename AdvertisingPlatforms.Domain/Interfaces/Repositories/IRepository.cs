namespace AdvertisingPlatforms.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        int Add(T entry);
        T Update(T entry);
        int Delete(T entry);
    }
}
