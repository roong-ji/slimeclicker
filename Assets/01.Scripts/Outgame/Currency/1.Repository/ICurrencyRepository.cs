public interface ICurrencyRepository
{
    void Save<T>(T data);
    void Load<T>(T data);
}