using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public WeatherDefinition.WeatherType currentWeather;
    public TileDefinition.TileType tileType;

    GameObject tileDemoObject;
    TileVisualData tvData;
    TileVisual tv;

    private void Start()
    {
        tileDemoObject = new GameObject("Demo Tile");
        tileDemoObject.transform.position = transform.position;
        tv = tileDemoObject.AddComponent<TileVisual>();
        tvData = GetComponent<TileVisualData>();
    }

    private void Update()
    {
        if (tvData.IsBuilt())
            SetSprites();
    }

    void SetSprites()
    {
        tv.SetWeatherSprite(tvData.GetWeatherSprite(currentWeather));
        tv.SetTerrainSprite(tvData.GetTerrainSprite(currentWeather, tileType));
    }
}
