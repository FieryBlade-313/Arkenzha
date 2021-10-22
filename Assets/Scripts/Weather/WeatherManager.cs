using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private WeatherObject weatherObject = new WeatherObject();

    public WeatherObject.Weather GetCurrentWeather()
    {
        return weatherObject.GetCurrentWeather();
    }

    public WeatherDefinition.WeatherType GetCurrentWeatherType()
    {
        return weatherObject.GetCurrentWeather().weatherType;
    }

    public void ProgressWeather()
    {
        weatherObject.ProgressWeather();
    }
}
