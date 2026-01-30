public interface IRepository<T>
{
    void Save(T data);
    T Load();
}