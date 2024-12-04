using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Utils
{
    internal static class TextureManager
    {
        public static Dictionary<string, Texture2D> Textures;

        public static void LoadTextures(ContentManager content)
        {
            Textures = new Dictionary<string, Texture2D>
            {
                ["Player"] = content.Load<Texture2D>("gordon"),
                ["RoadTile"] = content.Load<Texture2D>("DirtTile"),
                ["Box"] = content.Load<Texture2D>("Box"),
                ["DestinationPointTile"] = content.Load<Texture2D>("DestinationTile"),
            };
        }
    }
}
