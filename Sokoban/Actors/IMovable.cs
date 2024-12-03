using Sokoban.Actions;
using Sokoban.Map.Tiles;

namespace Sokoban.Actors
{
    public interface IMovable
    {
        bool TryMoveTo(Tile tile);
    }
}