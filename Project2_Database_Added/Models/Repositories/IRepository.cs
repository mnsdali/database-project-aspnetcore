namespace Project2_Database_Added.Models.Repositories
{
    public interface IRepository<T>
    {
        T Get(int Id);
        IEnumerable<T> GetAll();
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
    }
}
