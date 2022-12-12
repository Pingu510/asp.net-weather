
using System.Threading;
using System.Threading.Tasks;

namespace Arbetsprov.CSharp.Web.Contracts
{
    public interface IWeatherService
    {
        Task<Models.ServiceModels.LocationForecast.Root> GetLocationForecastAsync(double latitude, double longitude, CancellationToken cancellationToken);
    }
}