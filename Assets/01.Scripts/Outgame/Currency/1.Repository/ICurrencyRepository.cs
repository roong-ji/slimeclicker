public interface ICurrencyRepository
{
    void Save(Currency currency);
    Currency Load();
}