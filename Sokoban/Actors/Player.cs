using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Actions;
using Sokoban.Field.Tiles;

namespace Sokoban.Actors
{
    public class Player : Actor
    {
        public void Initialize(Texture2D texture, Tile tile)
        {
            Texture = texture;
            CorrentTile = tile; 
        }

        public int GetMovePriority()
        {
            throw new System.NotImplementedException();
        }

        public void Move(Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    if (CorrentTile.Left != null && CorrentTile.Left is IOccupiable)
                    {
                        CorrentTile.Occupand = null;
                        CorrentTile = CorrentTile.Left;
                        CorrentTile.Occupand = this;
                    }
                    break;
                case Keys.Right:
                    if (CorrentTile.Right != null && CorrentTile.Right is IOccupiable)
                    {
                        CorrentTile.Occupand = null;
                        CorrentTile = CorrentTile.Right;
                        CorrentTile.Occupand = this;
                    }
                    break;
                case Keys.Up:
                    if (CorrentTile.Top != null && CorrentTile.Top is IOccupiable)
                    {
                        CorrentTile.Occupand = null;
                        CorrentTile = CorrentTile.Top;
                        CorrentTile.Occupand = this;
                    }
                    break;
                case Keys.Down:
                    if (CorrentTile.Bottom != null && CorrentTile.Bottom is IOccupiable)
                    {
                        CorrentTile.Occupand = null;
                        CorrentTile = CorrentTile.Bottom;
                        CorrentTile.Occupand = this;
                    }
                    break;
                default:
                    break;
            }
                
        }
    }
}