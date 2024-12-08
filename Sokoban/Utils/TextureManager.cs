using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban.Utils
{
    internal static class TextureManager
    {
        public static Dictionary<string, Texture2D> Textures;
        public static Dictionary<string, SpriteFont> Fonts;

        public static void LoadResources(ContentManager content)
        {
            Textures = new Dictionary<string, Texture2D>
            {
                ["Player"] = content.Load<Texture2D>("gordon"),
                ["RoadTile"] = content.Load<Texture2D>("DirtTile"),
                ["Box"] = content.Load<Texture2D>("Box"),
                ["DestinationPointTile"] = content.Load<Texture2D>("DestinationTile"),
                ["WallTile"] = content.Load<Texture2D>("Rock"),
                ["Button"] = content.Load<Texture2D>("Button"),
                ["MenuBG"] = content.Load<Texture2D>("MenuBackground"),
            };

            Fonts = new Dictionary<string, SpriteFont>
            {
                ["Base"] = content.Load<SpriteFont>("EndText"),
            };
        }
    }
}
