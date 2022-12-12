using System.Collections.Generic;
using System;

namespace Arbetsprov.CSharp.Web.Models.WeatherData
{
    public class Data
    {
        public Instant Instant { get; set; }
        public Next1Hours Next1Hours { get; set; }
    }

    public class Details
    {
        public double? AirTemperature { get; set; }
        public double? WindFromDirection { get; set; }
        public double? WindSpeed { get; set; }
        public double? PrecipitationAmount { get; set; }
    }

    public class Instant
    {
        public Details Details { get; set; }
    }

    public class Meta
    {
        public DateTime? UpdatedAt { get; set; }
        public Units Units { get; set; }
    }

    public class Next1Hours
    {
        public Summary Summary { get; set; }
        public Details Details { get; set; }
    }

    public class Next6Hours
    {
        public Summary Summary { get; set; }
        public Details Details { get; set; }
    }

    public class Properties
    {
        public Meta Meta { get; set; }
        public List<Timeseries> Timeseries { get; set; }
    }

    public class WeatherData
    {
        public Properties Properties { get; set; }
    }

    public class Summary
    {
        public string SymbolCode { get; set; }
    }

    public class Timeseries
    {
        public DateTime? Time { get; set; }
        public Data Data { get; set; }
    }

    public class Units
    {
        public string AirTemperature { get; set; }
        public string PrecipitationAmount { get; set; }
        public string RelativeHumidity { get; set; }
        public string WindSpeed { get; set; }
    }
}