using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    private TileManager.Island island;
    private int row, col;

    private TileVisual[] tileVisuals;
    public void SetIsland(TileManager.Island island) => this.island = island;

    public void SetRow(int row) => this.row = row;

    public void SetCol(int col) => this.col = col;
    
    public void CreateIslandTiles()
    {

        TileDefinition.TileStructure[] generatedTileSetup = GenerateDifferentTiles();
        tileVisuals = new TileVisual[row * col];
        int t = 0;
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                GameObject tile = new GameObject("Tile");
                tile.transform.SetParent(transform);
                tile.transform.SetPositionAndRotation(island.GetTilePosition(i, j), Quaternion.identity);
                island.SetTileValue(i, j, generatedTileSetup[t]);
                tileVisuals[t++] = tile.AddComponent<TileVisual>();
            }
        }
    }

    private TileDefinition.TileStructure[] GenerateDifferentTiles()
    {
        TileDefinition.TileType[] tileTypes = (TileDefinition.TileType[])System.Enum.GetValues(typeof(TileDefinition.TileType));
        int typesAmount = tileTypes.Length;

        TileDefinition.TileStructure[] temp = new TileDefinition.TileStructure[row * col];
        for(int t = 0; t < row * col; t++)
            temp[t] = new TileDefinition.TileStructure() { ownerIndex = 1, tileLevel = 1, tileType = tileTypes[t % typesAmount] };

        ShuffleTiles(temp);
        return temp;
    }

    private void ShuffleTiles(TileDefinition.TileStructure[] tiles)
    {
        System.Random rnd = new System.Random();
        int n = tiles.Length;
        while(n>1)
        {
            int index = rnd.Next(n);

            TileDefinition.TileType tempType = tiles[n - 1].tileType;
            tiles[n - 1].tileType = tiles[index].tileType;
            tiles[index].tileType = tempType;

            n--;
        }
    }

    public void UpdateTilesVisual(WeatherDefinition.WeatherType currentWeatherType, TileVisualData tileVisualData)
    {
        for(int i=0;i<row;i++)
            for(int j=0;j<col;j++)
            {
                SetTileVisual(i * col + j, tileVisualData.GetWeatherSprite(currentWeatherType), tileVisualData.GetTerrainSprite(currentWeatherType, island.GetTileValue(i, j).tileType));
            }
    }

    private void SetTileVisual( int tileVisualIndex , Sprite currentWeatherSprite, Sprite tileSprite)
    {
        tileVisuals[tileVisualIndex].SetWeatherSprite(currentWeatherSprite);
        tileVisuals[tileVisualIndex].SetTerrainSprite(tileSprite);
    }
}
