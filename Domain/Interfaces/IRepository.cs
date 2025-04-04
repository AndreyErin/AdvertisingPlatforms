namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Add(T entry);
        T Update(T entry);
        int Delete(T entry);
    }
}
