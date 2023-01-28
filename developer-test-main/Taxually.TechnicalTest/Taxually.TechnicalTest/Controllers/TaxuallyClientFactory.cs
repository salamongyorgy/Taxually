namespace Taxually.TechnicalTest.Controllers
{
    public class TaxuallyClientFactory
    {
        public static T GetInstance<T>() where T : new()
        {
            T instance = new T();
            return instance;
        }
    }
}
