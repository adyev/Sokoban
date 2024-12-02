using Sokoban.Actors;
using Sokoban.Map.Tiles;

namespace Sokoban.Utils
{
    public class Mapper
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

        public static Actor SymbolToActor(char symbol)
        {
            return symbol switch
            {
                'P' => new Player(),
                'B' => new Box(),
                _ => null,
            };
        }
    }
}