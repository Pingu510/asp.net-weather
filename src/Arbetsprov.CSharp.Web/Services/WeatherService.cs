using Arbetsprov.CSharp.Web.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Arbetsprov.CSharp.Web.Services
{
    public class WeatherService : IWeatherService
    {
        private static HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public WeatherService(IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            PrepHttpClient();
        }

        private void PrepHttpClient()
        {
            var baseUrl = _configuration.GetValue<string>("Settings:WeatherForecastURL");
            _client = new HttpClient
            {
                BaseAddress = !string.IsNullOrWhiteSpace(baseUrl) ? new Uri(baseUrl) : null
            };
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("XlentCodeTest", "1.0.1"));
        }


        public async Task<Models.ServiceModels.LocationForecast.Root> GetLocationForecastAsync(double latitude, double longitude, CancellationToken cancellationToken)
        {
            string request = $"?lat={latitude}&lon={longitude}";
            HttpResponseMessage responseMessage = await _client.GetAsync(request, cancellationToken);
            try
            {
                responseMessage.EnsureSuccessStatusCode();

                var locationForecastResponse = await responseMessage.Content.ReadFromJsonAsync<Models.ServiceModels.LocationForecast.Root>(cancellationToken: cancellationToken);
                return locationForecastResponse;
            }
            catch (SerializationException e)
            {
                _logger.LogError($"Could not deserialize LocationForecast. Error: {e.Message} \n {e.InnerException?.Message} ");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not fetch from weather api. Code: {responseMessage.StatusCode} Reason: {responseMessage.ReasonPhrase}");
                return null;
            }
        }
    }
}
