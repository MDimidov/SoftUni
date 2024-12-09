document.addEventListener("DOMContentLoaded", function(event){
    const btnSubmit = document.querySelector('#submit');
    btnSubmit.addEventListener('click', attachEvents);
    const weatherSymbols = {
        Sunny: '&#x2600;',
        "Partly sunny": '&#x26C5;',
        Overcast: '&#x2601;',
        Rain: '&#x2614;',
        Degrees: '&#176;',
    }
    
    function attachEvents() {
        const input = document.querySelector('#location').value;
        urlGetWeather = `http://localhost:3030/jsonstore/forecaster/locations`;
        
        fetch(urlGetWeather)
            .then((response) => {
                if (!response.ok){
                    throw new Error("Cannot connect to the server");
                }
                return response.json();
            })
            .then((data) => {
                const objCity = data.find(d => d.code === input || d.name === input);
                if(objCity){
                    getWeatherToday(objCity);
                    getWeatherUpcoming(objCity);
                } else {
                    throw new Error("Please enter valid city");
                    
                }
            })
    }

    function getWeatherToday(objCity) {
        if (objCity){
            const url = `http://localhost:3030/jsonstore/forecaster/today/${objCity.code}`;
         
            fetch(url)
                .then((response) => {
                    if(!response.ok){
                        throw new Error(`HTTP Error: ${response.status}`);
                    }

                    return response.json();
                })
                .then((data) => {
                    createCurrentElements(data);
                });
        } else {
            throw new Error("Please enter valid city");
        }
    };

    function getWeatherUpcoming(objCity) {
        if (objCity){
            const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${objCity.code}`;
         
            fetch(url)
                .then((response) => {
                    if (!response.ok) {
                        throw new Error(`HTTP Error: ${response.status}`);
                    }

                    return response.json();
                })
                .then((data) => {
                    createUpcomingElements(data);
                });
        } else {
            throw new Error("Please enter valid city");
        }
    };

    function createCurrentElements(data) {
        const divCurrent = document.querySelector('#current');
        const divLabel = document.querySelector('#current>.label');
        divCurrent.innerHTML = '';
        divCurrent.appendChild(divLabel);

        const divIdForecast = document.querySelector('#forecast');
        divIdForecast.style.display = 'block';

        const divClassForecast = document.createElement('div');
        divClassForecast.classList.add('forecasts');

        const spanConditionSymbol = document.createElement('span');
        spanConditionSymbol.classList.add('condition', 'symbol');
        spanConditionSymbol.innerHTML = weatherSymbols[data.forecast.condition];
        divClassForecast.appendChild(spanConditionSymbol);
        
        const spanCondition = document.createElement('span');
        spanCondition.classList.add('condition');
        
        const spanCityName = document.createElement('span');
        spanCityName.classList.add('forecast-data');
        spanCityName.textContent = data.name;
        spanCondition.appendChild(spanCityName);
        
        const spanDegrees = document.createElement('span');
        spanDegrees.classList.add('forecast-data');
        spanDegrees.innerHTML = `${data.forecast.low}${weatherSymbols.Degrees}/${data.forecast.high}${weatherSymbols.Degrees}`;
        spanCondition.appendChild(spanDegrees);
        
        const spanConditionName = document.createElement('span');
        spanConditionName.classList.add('forecast-data');
        spanConditionName.textContent = data.forecast.condition;
        spanCondition.appendChild(spanConditionName);
        
        divClassForecast.appendChild(spanCondition);

        divCurrent.appendChild(divClassForecast);   
    }

    function createUpcomingElements(data) {
        const divUpcoming = document.querySelector('#upcoming');
        const divLabel = document.querySelector('#upcoming>.label');
        divUpcoming.innerHTML = '';
        divUpcoming.appendChild(divLabel);

        const divClassForecastInfo = document.createElement('div');
        divClassForecastInfo.classList.add('forecast-info');

        for (const element of data.forecast) {
            const spanUpcoming = document.createElement('span');
            spanUpcoming.classList.add('upcoming');
            
            const spanUpcomingSymbol = document.createElement('span');
            spanUpcomingSymbol.classList.add('symbol');
            spanUpcomingSymbol.innerHTML = weatherSymbols[element.condition];
            spanUpcoming.appendChild(spanUpcomingSymbol);
        
            const spanDegrees = document.createElement('span');
            spanDegrees.classList.add('forecast-data');
            spanDegrees.innerHTML = `${element.low}${weatherSymbols.Degrees}/${element.high}${weatherSymbols.Degrees}`;
            spanUpcoming.appendChild(spanDegrees);
        
            const spanConditionName = document.createElement('span');
            spanConditionName.classList.add('forecast-data');
            spanConditionName.textContent = element.condition;
            spanUpcoming.appendChild(spanConditionName);
        
            divClassForecastInfo.appendChild(spanUpcoming);
        
            divUpcoming.appendChild(divClassForecastInfo);   
        };
    }
    
});