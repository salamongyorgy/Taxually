using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;

namespace Taxually.TechnicalTest.Controllers {
    public class TaxuallyClientFactory {
        public static T GetInstance<T> () where T : new () {
            T instance = new ();
            return instance;
        }
    }
}