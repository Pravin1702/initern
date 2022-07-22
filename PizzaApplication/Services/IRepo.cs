namespace PizzaApplication.Services
{
    public interface IRepo<K,T>
    {
        T Get(K id);
        IEnumerable<T> GetAll();
        T Add(T item);
        T Update(T item);
        T Delete(K id);
    }
}
