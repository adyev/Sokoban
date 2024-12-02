using Sokoban.Actions;
using Sokoban.Map.Tiles;

namespace Sokoban.Actors
{
    public interface IMovable
    {
        void MoveTo(Tile tile);
        int GetMovePriority();
    }
}