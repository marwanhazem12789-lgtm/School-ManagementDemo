namespace School_ManagementDemo.Genarics
{
    public interface IGenaricRepo<T> where T : class
    {
       Task<List<T>> GetAll();
       Task<T> GetById(int Id);
        Task add(T item);
        void remove(T item);
        void Update(T item);
    }
}
