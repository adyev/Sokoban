using Microsoft.Xna.Framework.Graphics;
using Sokoban.Actors;
using Sokoban.Utils;

namespace Sokoban.Field.Tiles
{
    public abstract class Tile
    {
        Texture2D Texture;
        public Point PositionOnField { get; set; }
        public Actor Occupand { get; set; }
        public Tile(Point position)
        {
            PositionOnField = position;
            Occupand = null;
        }
        public Tile(Point position, Actor occupand)
        {
            PositionOnField = position;
            Occupand = occupand;
        }
    }
}