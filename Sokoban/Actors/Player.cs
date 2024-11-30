using Sokoban.Actions;

namespace Sokoban.Actors
{
    public class Player : IMovable
    {
        public int GetMovePriority()
        {
            throw new System.NotImplementedException();
        }

        public MoveAction Move()
        {
            return null;
        }
    }
}