namespace EShoppingMVCApp.Services
{
    public interface IRepo<K, T>
    {
        Task<T> Register(T item);
        //Read
        Task<T> Login(T item);
        //Update
        Task<T> UpdatePassword(T item);
        //Delete
        Task<T> DeleteUser(K key);
    }
}
