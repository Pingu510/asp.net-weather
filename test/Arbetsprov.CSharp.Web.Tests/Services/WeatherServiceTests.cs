using Arbetsprov.CSharp.Web.Contracts;
using Arbetsprov.CSharp.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Arbetsprov.CSharp.Web.Tests.Services
{
	public class WeatherServiceTests
	{
		private readonly IWeatherService _weatherService;

		// todo DI
		public WeatherServiceTests()
		{
			var services = new ServiceCollection();
			services.AddTransient<IWeatherService, WeatherService>();
			var serviceProvider = services.BuildServiceProvider();
			_weatherService = serviceProvider.GetService<IWeatherService>();
		}

		[Fact]
		public void CanConstruct()
		{
			//var service = new WeatherService();
			Assert.NotNull(_weatherService);
		}

		[Fact]
		public async void CallWeatherAPI()
		{
			var forecast = await _weatherService.GetLocationForecastAsync(63.8258, 20.2630, new System.Threading.CancellationToken());
			Assert.NotNull(forecast);
		}

		[Fact]
		public async void CallWeatherAPINull()
		{
			var nowhere = await _weatherService.GetLocationForecastAsync(0, 0, new System.Threading.CancellationToken());
			Assert.Null(nowhere);
		}
	}
}
