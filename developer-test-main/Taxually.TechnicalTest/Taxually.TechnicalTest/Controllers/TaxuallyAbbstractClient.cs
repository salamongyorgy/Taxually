using Taxually.TechnicalTest.Controllers.Parameters.Interfaces;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers
{
    public abstract class BaseClient<TParam> :  ITaxuallyClient<TParam>
    {
        public abstract TParam GetProcessedData(VatRegistrationRequest vat);
        public abstract Task Process(string target, TParam parameter);
    }
}
