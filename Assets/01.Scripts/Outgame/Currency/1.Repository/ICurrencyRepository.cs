public interface ICurrencyRepository<T>
{
    void Save(T data);
    void Load(T data);
}