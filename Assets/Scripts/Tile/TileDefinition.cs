public class TileDefinition
{
    public enum TileType
    {
        plains,
        farmland,
        forest,
        mountain,
    }

    public struct TileStructure
    {
        public int ownerIndex;
        public int tileLevel;
        public TileType tileType;
    }
}
