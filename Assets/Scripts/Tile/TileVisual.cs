using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVisual : MonoBehaviour
{
    private SpriteRenderer tileWeatherRenderer;
    private SpriteRenderer tileTerrainRenderer;

    // Start is called before the first frame update
    void Start()
    {

        GameObject terrainObject = new GameObject("Terrian Object");
        terrainObject.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        terrainObject.transform.SetParent(transform);

        tileTerrainRenderer = terrainObject.AddComponent<SpriteRenderer>();
        tileWeatherRenderer = gameObject.AddComponent<SpriteRenderer>();

        tileTerrainRenderer.sortingOrder = 1;
    }

    public void SetTerrainSprite(Sprite sprite)
    {
        tileTerrainRenderer.sprite = sprite;
    }

    public void SetWeatherSprite(Sprite sprite)
    {
        tileWeatherRenderer.sprite = sprite;
    }

}
