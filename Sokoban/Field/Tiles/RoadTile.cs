
using Sokoban.Actors;

namespace Sokoban.Field.Tiles
{
    public class RoadTile : Tile, IOccupiable
    {
        string NameTag = "RoadTile";

        public void SetOccupand(Actor occupand)
        {
            Occupand = occupand;
        }
    }
}