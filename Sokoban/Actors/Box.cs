using System;
using Sokoban.Actions;
using Sokoban.Map.Tiles;
using Sokoban.Utils;

namespace Sokoban.Actors
{
    public class Box : Actor, IMovable
    {
        public override string NameTag
        {
            get => "Box";
        }
        public int GetMovePriority()
        {
            throw new NotImplementedException();
        }

        public void MoveTo(Tile tile)
        {
            CorrentTile.Occupand = null;
            tile.Occupand = this;
            CorrentTile = tile;
        }


        public override bool CanMoveTo(Directions direction)
        {
            switch (direction)
            {
                case Directions.RIGHT:
                    return (CorrentTile.Right != null && CorrentTile.Right.Occupand == null);
                case Directions.LEFT:
                    return (CorrentTile.Left != null && CorrentTile.Left.Occupand == null);
                case Directions.UP:
                    return (CorrentTile.Top != null && CorrentTile.Top.Occupand == null);
                case Directions.DOWN:
                    return (CorrentTile.Bottom != null && CorrentTile.Bottom.Occupand == null);
            }
            return false;
        }
    }
}