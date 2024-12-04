using System;
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
    }
}