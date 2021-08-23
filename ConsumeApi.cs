using Refit;
using System.Threading.Tasks;

namespace ApiRequest
{
    public interface ConsumeApi
    {
        [Get("/cep/v2/{cep}")]
        Task<Structure> GetAddressAsync(string cep);
    }
}
