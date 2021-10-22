using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVisualData : MonoBehaviour
{
    private bool isBuilt = false;

    [System.Serializable]
    public struct WeatherMapConnector
    {
        public WeatherDefinition.WeatherType weatherType;
        public Sprite sprite;
    };

    [System.Serializable]
    public struct TerrainMapConnector
    {
        public TerrainWeatherStructure terrainWeatherStructure;
        public Sprite sprite;
    };

    [System.Serializable]
    public struct TerrainWeatherStructure
    {
        public TileDefinition.TileType tileType;
        public WeatherDefinition.WeatherType tileWeather;
    };

    private Dictionary<WeatherDefinition.WeatherType, Sprite> weatherTileMap = new Dictionary<WeatherDefinition.WeatherType, Sprite>();
    private Dictionary<TerrainWeatherStructure, Sprite> terrainTileMap = new Dictionary<TerrainWeatherStructure, Sprite>();


    public WeatherMapConnector[] weatherMapConnector;
    public TerrainMapConnector[] terrainMapConnector;

    void Start()
    {
        foreach (WeatherMapConnector data in weatherMapConnector)
        {
            weatherTileMap.Add(data.weatherType, data.sprite);
        }

        foreach (TerrainMapConnector data in terrainMapConnector)
            terrainTileMap.Add(data.terrainWeatherStructure, data.sprite);

        isBuilt = true;
    }

    public bool IsBuilt()
    {
        return isBuilt;
    }

    public Sprite GetWeatherSprite(WeatherDefinition.WeatherType weatherType)
    {
        return weatherTileMap[weatherType];
    }

    public Sprite GetTerrainSprite(WeatherDefinition.WeatherType weatherType,TileDefinition.TileType tileType)
    {
        return terrainTileMap[new TerrainWeatherStructure() { tileType = tileType, tileWeather = weatherType }];
    }
}
