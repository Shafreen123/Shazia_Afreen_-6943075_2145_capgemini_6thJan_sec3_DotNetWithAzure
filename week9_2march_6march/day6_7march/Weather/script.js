function checkWeather(){

    let city = document.getElementById("cityInput").value;
    let result = document.getElementById("weatherResult");

    if(city === ""){
        result.innerHTML = "Please enter a city name.";
        return;
    }

    let weather;
    let temp;

    // Mock weather data
    let random = Math.floor(Math.random() * 3);

    if(random === 0){
        weather = "Sunny ☀";
        temp = "30°C";
        document.body.style.background = "yellow";
    }
    else if(random === 1){
        weather = "Rainy 🌧";
        temp = "20°C";
        document.body.style.background = "lightblue";
    }
    else{
        weather = "Cloudy ☁";
        temp = "25°C";
        document.body.style.background = "lightgray";
    }

    result.innerHTML =
        "City: " + city +
        "<br>Temperature: " + temp +
        "<br>Weather: " + weather;
}