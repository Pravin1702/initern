namespace EShoppingMVCApp.Services
{
    public interface IRepoCart<T>
    {
        Task<T> Get(T item);
        Task<ICollection<T>> GetAll();
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(T item);
    }
}
