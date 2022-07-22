namespace EShoppingAPIApp.Services
{
    public interface IRepo<K, T>
    {
        //Create
        T Add(T item);
        //Read
        IEnumerable<T> GetAll();
        //Read
        T Get(K key);
        //Update
        T Update(T item);
        //Delete
        T Delete(T item);
        //Add Cart
        T AddCart(T item);
        //View Carts
        IEnumerable<T> GetAllCart();
        T DeleteProductCart(T item);
        T AddSameProduct(T item);
        T DeleteSameProduct(T item);

    }
}

