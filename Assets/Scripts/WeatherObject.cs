using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherObject
{

    private int currWeatherIndex = 0;

    public struct Weather
    {
        public string weatherName;
        public WeatherDefinition.WeatherType weatherType;
        public WeatherEffect weatherEffect;
    }

    public Weather[] weather =
    {
        new Weather()
        {
            weatherName = "Blessings",
            weatherType = WeatherDefinition.WeatherType.Spring,
            weatherEffect = new WeatherEffect(2, new WeatherEffect.EffectsDeclaration[]{
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Food, resourceProductionMultipler = 1.2f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Gold, resourceProductionMultipler = 1.2f},
            })
        },

        new Weather()
        {
            weatherName = "Sun's Wraith",
            weatherType = WeatherDefinition.WeatherType.Summer,
            weatherEffect = new WeatherEffect(3, new WeatherEffect.EffectsDeclaration[]{
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Stone, resourceProductionMultipler = 1.2f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Wood, resourceProductionMultipler = 0.8f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ConstructionCost, constructionCostMultiplier = 0.8f},
            })
        },

        new Weather()
        {
            weatherName = "Dark Showers",
            weatherType = WeatherDefinition.WeatherType.Fall,
            weatherEffect = new WeatherEffect(2, new WeatherEffect.EffectsDeclaration[]{
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Food, resourceProductionMultipler = 1.2f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ConstructionCost, constructionCostMultiplier = 1.2f},
            })
        },

        new Weather()
        {
            weatherName = "Frosty Shadows",
            weatherType = WeatherDefinition.WeatherType.Winter,
            weatherEffect = new WeatherEffect(4, new WeatherEffect.EffectsDeclaration[]{
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Food, resourceProductionMultipler = 0.8f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Gold, resourceProductionMultipler = 0.8f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Stone, resourceProductionMultipler = 0.8f},
                new WeatherEffect.EffectsDeclaration(){effectType = WeatherEffect.EffectInfo.EffectType.ResourceProduction, targetResourceType = ResourceDefinition.ResourceType.Wood, resourceProductionMultipler = 1.2f},
            })
        },
    };

    public Weather GetCurrentWeather()
    {
        return weather[currWeatherIndex];
    }

    public void ProgressWeather()
    {
        currWeatherIndex = (currWeatherIndex + 1) % weather.Length;
    }
}
