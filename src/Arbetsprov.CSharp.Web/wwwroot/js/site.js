
const weatherForm = document.getElementById('weather-form');
const weatherContainer = document.getElementById('weather-data-container');

weatherForm?.addEventListener('submit', (e) => {
    e.preventDefault();
    populateWeatherForecast(latitud.value, longitud.value);
    weatherContainer.textContent = 'Hämtar väderdata!';
});

async function getWeatherAPIData(lat, lon) {
    let response = await fetch("https://localhost:44370/api/weather?lat=" + lat + "&lon=" + lon).catch((error => console.log(error)))
    return await response.json().catch((error => console.log(error)));
}

async function populateWeatherForecast(lat, lon) {
    try {
        let weatherData = (await getWeatherAPIData(lat, lon)).Properties;
        weatherContainer.innerHTML =
            `<div id="weather-data-forecast">
            <div id = "weather-data-meta">
                <div>Uppdaterad: ${weatherData.Meta.UpdatedAt}</div>
            </div >
            <div id="weather-data-cards"/>
        </div>`;
        let forecasts = document.getElementById('weather-data-cards');

        for (var i = 0; i < weatherData.Timeseries.length; i += 2) {
            if (i > 24 * 2) break;
            let htmlContainer = document.createElement("div");
            htmlContainer.className = "weather-data-timestamp";
            htmlContainer.innerHTML =
                `<div class="card-body">
                <h5 class="card-title">${weatherData.Timeseries[i].Data.Instant.Details.AirTemperature} °C</h5>
                <h6 class="card-subtitle mb-2 text-muted" id="weather-data-meta">${weatherData.Timeseries[i].Time}</h6>
                <p class="card-text">
                    <div>Vind: ${weatherData.Timeseries[i].Data.Instant.Details.WindSpeed} ${weatherData.Meta.Units.WindSpeed} </div>
                    <div>Nederbörd: ${weatherData.Timeseries[i].Data.Instant.Details.PrecipitationAmount} ${weatherData.Meta.Units.PrecipitationAmount} </div>
                    <div class="weather-icon">${weatherData.Timeseries[i].Data.Next1Hours.Summary.SymbolCode} </div>
                </p>   
            </div>`;
            forecasts.append(htmlContainer);
        }
    } catch (e) {
        weatherContainer.textContent = 'Kunde ej hämta väderdata, försök igen.'
    }
}