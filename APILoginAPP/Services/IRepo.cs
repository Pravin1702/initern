namespace APILoginAPP.Services
{
    public interface IRepo<K ,T>
    {
        T Add(T item);
        //Read
        T Get(T item);
        //Update
        T Update(T item);
        //Delete
        T Delete(K key);
    }
}
