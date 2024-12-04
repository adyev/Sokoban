using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Actors;
using Sokoban.Utils;

namespace Sokoban.Map.Tiles
{
    public abstract class Tile
    {
        public abstract string NameTag { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Actor Occupand { get; set; }
        public float Scale { get; set; }
        public Tile Left { get; set; }
        public Tile Right { get; set; }
        public Tile Top { get; set; }
        public Tile Bottom { get; set; }

        public void Initialize(Texture2D texture, float scale)
        {
            Texture = texture;
            Scale = scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null) 
                spriteBatch.Draw(Texture, Position, null, Color.White, 0f, new Vector2(Texture.Width / 2, Texture.Height / 2), Scale, SpriteEffects.None, 0f);
            Occupand?.Draw(spriteBatch, Occupand.GetScale(Texture.Height * Scale));
        }

        public void SetRelations(Tile[,] tiles, int y, int x)
        {
            if (x > 0)
                Left = tiles[y, x - 1];

            if (y > 0)
                Top = tiles[y - 1, x];

            if (x < tiles.GetLength(1) - 1)
                Right = tiles[y, x + 1];

            if (y < tiles.GetLength(0) - 1)
                Bottom = tiles[y + 1, x];
        }

        public Tile GetTileByDirection(Directions direction)
        {
            return direction switch
            {
                Directions.UP => Top,
                Directions.RIGHT => Right,
                Directions.DOWN => Bottom,
                Directions.LEFT => Left,
                _ => null
            };
        }
    }
}