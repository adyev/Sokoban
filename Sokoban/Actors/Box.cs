using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Map.Tiles;
using Sokoban.Utils;

namespace Sokoban.Actors
{
    public class Box : Actor, IInteractable, IMovable
    {
        public override string NameTag
        {
            get => "Box";
        }

        public void Interact(Actor actor)
        {
            if (actor is Player)
                TryMoveTo(
                    CorrentTile.GetTileByDirection(
                        GetInteractionDirection(actor)));
        }
        public bool TryMoveTo(Tile tile)
        {
            if (tile == null || tile is not IOccupiable)
                return false;
            var tileAsOccupiable = tile as IOccupiable;
            if (tile.Occupand == null)
                tileAsOccupiable.Occupy(this);
            else if (tile.Occupand is IInteractable interactable)
                    interactable.Interact(this);
            
            return tile == CorrentTile;
        }

        private Directions GetInteractionDirection(Actor actor)
        {
            var actorTile = actor.CorrentTile;
            if (actorTile.Left == CorrentTile)
                return Directions.LEFT;
            if (actorTile.Right == CorrentTile)
                return Directions.RIGHT;
            if (actorTile.Top == CorrentTile)
                return Directions.UP;
            if (actorTile.Bottom == CorrentTile)
                return Directions.DOWN;
            return Directions.NONE;
        }
        public override void Draw(SpriteBatch spriteBatch, float scale)
        {
            var color = Color.White;
            if (CorrentTile is DestinationPointTile)
                color *= 0.5f;
            spriteBatch.Draw(Texture, CorrentTile.Position, null, color, 0f, new Vector2(Texture.Width / 2, Texture.Height / 2), scale, SpriteEffects.None, 0f);
        }
    }
}