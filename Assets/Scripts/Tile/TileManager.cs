using UnityEngine;

public class TileManager
{
    public class Island
    {
        private HexGrid<TileDefinition.TileStructure> grid;

        public Island(int row, int col, float radius, Vector2 gridPosition, TileDefinition.TileStructure defaultValue)
        {
            grid = new HexGrid<TileDefinition.TileStructure>(row, col, radius, gridPosition, defaultValue);
        }

        public void SetTileValue(int i, int j, TileDefinition.TileStructure value)
        {
            grid.SetGridNodeValue(i, j, value);
        }

        public TileDefinition.TileStructure GetTileValue(int i, int j)
        {
            return grid.GetGridNodeValue(i, j);
        }

        public Vector2 GetTilePosition(int i, int j)
        {
            return grid.GetGridNodePosition(i, j);
        }

    }
    public Island CreateIsland(int row, int col, float radius, Vector2 gridPosition, TileDefinition.TileStructure defaultValue)
    {
        return new Island(row, col, radius, gridPosition, defaultValue);
    }

}
