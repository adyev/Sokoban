using Sokoban.Actors;

namespace Sokoban.Actions
{
    public abstract class Action
    {
        public Actor Actor { get; set; }
        public abstract void MakeAction();
    }
}