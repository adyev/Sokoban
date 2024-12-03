using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Map.Tiles;
using Sokoban.Utils;
using System;

namespace Sokoban.Actors
{
    public abstract class Actor
    {
        public Texture2D Texture { get; set; }
        public Tile CorrentTile { get; set; }
        public abstract string NameTag { get; }

        public virtual void Draw(SpriteBatch spriteBatch, float scale)
        {
            spriteBatch.Draw(Texture, CorrentTile.Position, null, Color.White, 0f, new Vector2(Texture.Width / 2, Texture.Height / 2), scale, SpriteEffects.None, 0f);
        }

        public virtual float GetScale(float tileHeigth)
        {
            return tileHeigth / Math.Max(Texture.Height, Texture.Width);
        }
    }
}