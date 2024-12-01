using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Actors;
using Sokoban.Utils;

namespace Sokoban.Field.Tiles
{
    public abstract class Tile
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Actor Occupand { get; set; }
        public float Scale { get; set; }
        public Tile Left { get; set; }
        public Tile Right { get; set; }
        public Tile Top { get; set; }
        public Tile Bottom { get; set; }

        public void Initialize(Texture2D texture, Vector2 position, float scale)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null) 
                spriteBatch.Draw(Texture, Position, null, Color.White, 0f, new Vector2(Texture.Width / 2, Texture.Height / 2), Scale, SpriteEffects.None, 0f);
            Occupand?.Draw(spriteBatch, Occupand.GetScale(Texture.Height * Scale));
        }

        public float GetScale(float height, int maxTileCount) => height / maxTileCount / Texture.Height;

        public void SetRelations(Tile[,] tiles, int y, int x)
        {
            var b = tiles.GetLength(1) - 1;
            var a = tiles.GetLength(0) - 1;
            if (x > 0)
                Left = tiles[y, x - 1];
            if (y > 0)
                Top = tiles[y - 1, x];
            if (x < tiles.GetLength(1) - 1)
                Right = tiles[y, x + 1];
            if (y < tiles.GetLength(0) - 1)
                Bottom = tiles[y + 1, x];
        }
    }
}