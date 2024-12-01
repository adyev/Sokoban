using Sokoban.Field.Tiles;

namespace Sokoban.Utils
{
    public class TerrainMapper
    {
        public static Tile SymbolToTile(char symbol)
        {
            return symbol switch
            {
                'W' => new WallTile(),
                'R' => new RoadTile(),
                'D' => new DestinationPointTile(),
                _ => new EmptyTile(),
            };
        }
    }
}