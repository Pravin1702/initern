namespace EShoppingMVCApp.Services
{
    public interface IReopProducts<K, T>
    {
        //Create
        Task<T> Add(T item);
        //Read
        Task<ICollection<T>> GetAll();
        //Read
        Task<T> Get(K key);
        //Update
        Task<T> Update(T item);
        //Delete
        Task<T> Delete(K key);
    }
}
