public interface IRepository<T>
{
    void Save(T currency);
    T Load();
}