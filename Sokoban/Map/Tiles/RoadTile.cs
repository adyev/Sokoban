
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Actors;

namespace Sokoban.Map.Tiles
{
    public class RoadTile : Tile, IOccupiable
    {
        public override string NameTag 
        {
            get
            {
                return "RoadTile";
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