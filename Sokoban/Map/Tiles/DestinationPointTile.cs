
using Sokoban.Actors;

namespace Sokoban.Map.Tiles
{
    public class DestinationPointTile : Tile, IOccupiable
    {
        public override string NameTag
        {
            get
            {
                return "DestinationPointTile";
            }
        }

        public void SetOccupand(Actor occupand)
        {
            Occupand = occupand;
        }
    }
}