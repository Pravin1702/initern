using FirstAPI.Models;

namespace FirstAPI.Services
{
    public interface IRepo<K, T>
    {
        //Create
        T Add(T item);
        //Read
        ICollection<T> GetAll();
        //Read
        T Get(K key);
        //Update
        T Update(T item);
        //Delete
        T Delete(K key);
       // object Add(User user);
    }
}
