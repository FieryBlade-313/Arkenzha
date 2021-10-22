using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandsManager : MonoBehaviour
{
    TileManager tileManager = new TileManager();

    [SerializeField]
    private float radius;

    [SerializeField]
    private WeatherManager weatherManager;
    [System.Serializable]
    private struct IslandGenerationData
    {
        public Transform location;
        public int row;
        public int col;
    }

    [SerializeField]
    private IslandGenerationData[] islandsData;

    private IslandManager[] islandManagers;
    private TileVisualData tileVisualData;

    private void Start()
    {
        tileVisualData = GetComponent<TileVisualData>();

        TileDefinition.TileStructure defaultTileValue = new TileDefinition.TileStructure(){ ownerIndex = 1, tileLevel = 1, tileType = TileDefinition.TileType.plains };
        islandManagers = new IslandManager[islandsData.Length];

        int t = 0;
        foreach(IslandGenerationData data in islandsData)
        {
            GameObject islandObject = new GameObject("Island Object");
            islandObject.transform.SetParent(transform);
            islandManagers[t] = islandObject.AddComponent<IslandManager>();
            islandManagers[t].SetRow(data.row);
            islandManagers[t].SetCol(data.col);
            islandManagers[t++].SetIsland(tileManager.CreateIsland(data.row, data.col, radius, data.location.position, defaultTileValue));
        }

        BuildIslandsTile();
    }

    private void BuildIslandsTile()
    {
        foreach (IslandManager islandsManager in islandManagers)
            islandsManager.CreateIslandTiles();
    }

    private void Update()
    {
        if (tileVisualData.IsBuilt())
            UpdateIslandsVisual();
    }

    public void UpdateIslandsVisual()
    {

        foreach(IslandManager islandManager in islandManagers)
        {
            islandManager.UpdateTilesVisual(weatherManager.GetCurrentWeatherType(), tileVisualData);
        }
    }
}
