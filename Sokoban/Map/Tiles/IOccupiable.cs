using Sokoban.Actors;

namespace Sokoban.Map.Tiles
{
    internal interface IOccupiable
    {
        void Occupy(Actor occupand);
    }
}
