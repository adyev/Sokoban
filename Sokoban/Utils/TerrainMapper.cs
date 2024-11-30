using Sokoban.Field.Tiles;

namespace Sokoban.Utils
{
    public class TerrainMapper
    {
        public static Tile SymbolToTile(char symbol, int x, int y)
        {
            return symbol switch
            {
                'W' => new WallTile(new Point(x, y)),
                'R' => new RoadTile(new Point(x, y)),
                'D' => new DestinationPointTile(new Point(x, y)),
                _ => new EmptyTile(new Point(x, y)),
            };
        }
    }
}