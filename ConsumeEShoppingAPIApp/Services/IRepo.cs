namespace ConsumeEShoppingAPIApp.Services
{
    public interface IRepo<K, T>
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
        //Add Cart
        Task<T> AddCart(T item);
        //View Carts
        Task<ICollection<T>> GetAllCart();
        Task<T> DeleteProductCart(T item);
        Task<T> AddSameProduct(T item);
        Task<T> DeleteSameProduct(T item);



    }
}
