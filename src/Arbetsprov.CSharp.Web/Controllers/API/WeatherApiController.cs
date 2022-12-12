using Arbetsprov.CSharp.Web.Contracts;
using Arbetsprov.CSharp.Web.Extensions;
using Arbetsprov.CSharp.Web.Models.WeatherData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Arbetsprov.CSharp.Web.Controllers.API
{
    [Route("api/weather")]
    public class WeatherApiController : Controller
    {
        private readonly ILogger _logger;
        private readonly IWeatherService _weatherService;

        public WeatherApiController(ILogger<HomeController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        // https://localhost:44370/api/weather?lat=1&lon=1
        [HttpGet]
        public async Task<string> GetWeatherDataAsync(string lat = "63.8258", string lon = "20.2630")
        {
            // todo check correct input
            if (double.TryParse(lat, out double latitude) && double.TryParse(lon, out double longitude))
            {
                var cancellationToken = new CancellationToken();
                var forecast = await _weatherService.GetLocationForecastAsync(latitude, longitude, cancellationToken);
                if (forecast != null)
                {
                    var weatherData = ServiceModelsHelper.TranslateLocationForecastToWeatherData(forecast);
                    return JsonSerializer.Serialize<WeatherData>(weatherData);
                }
            }
            return "";
        }
    }
}
