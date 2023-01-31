using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers.Parameters.Interfaces
{
    public interface ITaxuallyClient<T>
    {
        Task Process(string target, T parameter);

        T GetProcessedData(VatRegistrationRequest vat);
    }
}
