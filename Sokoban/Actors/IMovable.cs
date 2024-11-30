using Sokoban.Actions;

namespace Sokoban.Actors
{
    public interface IMovable
    {
        MoveAction Move();
        int GetMovePriority();
    }
}