using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace Arbetsprov.CSharp.Web.Models.ServiceModels.LocationForecast
{
    public class Data
    {
        [JsonPropertyName("instant")]
        public Instant instant { get; set; }

        [JsonPropertyName("next_12_hours")]
        public Next12Hours next_12_hours { get; set; }

        [JsonPropertyName("next_1_hours")]
        public Next1Hours next_1_hours { get; set; }

        [JsonPropertyName("next_6_hours")]
        public Next6Hours next_6_hours { get; set; }
    }

    public class Details
    {
        [JsonPropertyName("air_pressure_at_sea_level")]
        public double? air_pressure_at_sea_level { get; set; }

        [JsonPropertyName("air_temperature")]
        public double? air_temperature { get; set; }

        [JsonPropertyName("cloud_area_fraction")]
        public double? cloud_area_fraction { get; set; }

        [JsonPropertyName("relative_humidity")]
        public double? relative_humidity { get; set; }

        [JsonPropertyName("wind_from_direction")]
        public double? wind_from_direction { get; set; }

        [JsonPropertyName("wind_speed")]
        public double? wind_speed { get; set; }

        [JsonPropertyName("precipitation_amount")]
        public double? precipitation_amount { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double?> coordinates { get; set; }
    }

    public class Instant
    {
        [JsonPropertyName("details")]
        public Details details { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("updated_at")]
        public DateTime? updated_at { get; set; }

        [JsonPropertyName("units")]
        public Units units { get; set; }
    }

    public class Next12Hours
    {
        [JsonPropertyName("summary")]
        public Summary summary { get; set; }

        [JsonPropertyName("details")]
        public Details details { get; set; }

    }

    public class Next1Hours
    {
        [JsonPropertyName("summary")]
        public Summary summary { get; set; }

        [JsonPropertyName("details")]
        public Details details { get; set; }
    }

    public class Next6Hours
    {
        [JsonPropertyName("summary")]
        public Summary summary { get; set; }

        [JsonPropertyName("details")]
        public Details details { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("meta")]
        public Meta meta { get; set; }

        [JsonPropertyName("timeseries")]
        public List<Timeseries> timeseries { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry geometry { get; set; }

        [JsonPropertyName("properties")]
        public Properties properties { get; set; }
    }

    public class Summary
    {
        [JsonPropertyName("symbol_code")]
        public string symbol_code { get; set; }
    }

    public class Timeseries
    {
        [JsonPropertyName("time")]
        public DateTime? time { get; set; }

        [JsonPropertyName("data")]
        public Data data { get; set; }
    }

    public class Units
    {
        [JsonPropertyName("air_pressure_at_sea_level")]
        public string air_pressure_at_sea_level { get; set; }

        [JsonPropertyName("air_temperature")]
        public string air_temperature { get; set; }

        [JsonPropertyName("cloud_area_fraction")]
        public string cloud_area_fraction { get; set; }

        [JsonPropertyName("precipitation_amount")]
        public string precipitation_amount { get; set; }

        [JsonPropertyName("relative_humidity")]
        public string relative_humidity { get; set; }

        [JsonPropertyName("wind_from_direction")]
        public string wind_from_direction { get; set; }

        [JsonPropertyName("wind_speed")]
        public string wind_speed { get; set; }
    }
}