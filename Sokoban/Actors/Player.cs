using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Map.Tiles;
using Sokoban.Utils;

namespace Sokoban.Actors
{
    public class Player : Actor, IMovable
    {
        public override string NameTag { get => "Player"; }
        public void Initialize(Texture2D texture, Tile tile)
        {
            Texture = texture;
            CorrentTile = tile; 
        }

        public bool TryMoveTo(Tile tile)
        {
            if (tile == null || tile is not IOccupiable)
                return false;
            var tileAsOccupiable = tile as IOccupiable;
            if (tile.Occupand == null)
                tileAsOccupiable.Occupy(this);
            else if (tile.Occupand is IInteractable interactable)
            {
                interactable.Interact(this);
                if (tile.Occupand == null)
                    tileAsOccupiable.Occupy(this);
            }

            return tile == CorrentTile;
        }
    }
}