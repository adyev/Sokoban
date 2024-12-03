using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Actions;
using Sokoban.Map.Tiles;
using Sokoban.Utils;

namespace Sokoban.Actors
{
    public class Player : Actor
    {
        public override string NameTag { get => "Player"; }
        public void Initialize(Texture2D texture, Tile tile)
        {
            Texture = texture;
            CorrentTile = tile; 
        }

        public int GetMovePriority()
        {
            throw new System.NotImplementedException();
        }

        public void MoveTo(Tile tile)
        {
            CorrentTile.Occupand = null;
            tile.Occupand = this;
            CorrentTile = tile;
        }

        public void Move(Keys key)
        {
            var direction = Controls.GetMoveDirection(key);
            var tileToMove = CorrentTile.GetTileByDirection(direction);
            if (tileToMove != null && tileToMove is IOccupiable)
            {
                if (tileToMove.Occupand != null) 
                {
                    if (tileToMove.Occupand.CanMoveTo(direction))
                    {
                        ((IMovable)tileToMove.Occupand).MoveTo(tileToMove.GetTileByDirection(direction));
                        MoveTo(tileToMove);
                    }
                }
                else
                    MoveTo(tileToMove);
            }
        }
    }
}