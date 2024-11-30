using System;
using Sokoban.Actions;

namespace Sokoban.Actors
{
    public class Box : IMovable
    {
        public int GetMovePriority()
        {
            throw new NotImplementedException();
        }

        public MoveAction Move()
        {
            throw new NotImplementedException();
        }

        MoveAction IMovable.Move()
        {
            throw new NotImplementedException();
        }
    }
}