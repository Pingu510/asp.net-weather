using Arbetsprov.CSharp.Web.Models.WeatherData;

namespace Arbetsprov.CSharp.Web.Extensions
{
    public static class ServiceModelsHelper
    {
        public static WeatherData TranslateLocationForecastToWeatherData(Models.ServiceModels.LocationForecast.Root locationForecast)
        {
            var weatherData = new WeatherData()
            {
                Properties = new Properties()
                {
                    Meta = new Meta()
                    {
                        UpdatedAt = locationForecast.properties.meta.updated_at,
                        Units = new Units()
                        {
                            AirTemperature = locationForecast.properties.meta.units.air_temperature,
                            PrecipitationAmount = locationForecast.properties.meta.units.precipitation_amount,
                            RelativeHumidity = locationForecast.properties.meta.units.relative_humidity,
                            WindSpeed = locationForecast.properties.meta.units.wind_speed
                        }
                    },
                    Timeseries = new System.Collections.Generic.List<Timeseries>()
                }
            };

            foreach (var timeseries in locationForecast.properties.timeseries)
            {
                var timeInstance = new Timeseries()
                {
                    Time = timeseries.time,
                    Data = new Data()
                    {
                        Instant = new Instant()
                        {
                            Details = new Details()
                            {
                                AirTemperature = timeseries.data.instant.details?.air_temperature,
                                PrecipitationAmount = timeseries.data.instant.details?.precipitation_amount,
                                WindFromDirection = timeseries.data.instant.details?.wind_from_direction,
                                WindSpeed = timeseries.data.instant.details?.wind_speed
                            }
                        },
                        Next1Hours = new Next1Hours()
                        {
                            Summary = new Summary()
                            {
                                SymbolCode = timeseries.data.next_1_hours?.summary?.symbol_code
                            }
                        }
                    }
                };

                weatherData.Properties.Timeseries.Add(timeInstance);
            }

            return weatherData;
        }
    }
}
