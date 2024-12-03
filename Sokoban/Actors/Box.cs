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
    }
}