using Sokoban.Map.Tiles;
using Sokoban.Actors;

namespace Sokoban.Actions
{
    public class MoveAction : Action

    {
        Tile Destination;
        Tile Start;
        Actor Actor;

        public MoveAction(Tile start, Tile destination, Actor actor)
        {
            Start = start;
            Destination = destination;
            Actor = actor;
        }

        public override void MakeAction()
        {
            Start.Occupand = null;
            Destination.Occupand = Actor;

        }

        public bool IsMovePosible()
        {
            return true;
        }
    }
}