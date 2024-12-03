
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

        public void Occupy(Actor occupand)
        {
            if (Occupand == null)
            {
                occupand.CorrentTile.Occupand = null;
                Occupand = occupand;
                occupand.CorrentTile = this;
            }
        }
    }
}