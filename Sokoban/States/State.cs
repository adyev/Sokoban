using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.States
{
    internal abstract class State(Game game, ContentManager content, Texture2D backgroundTexture)
    {
        public Texture2D BackgroundTexture { get; private set; } = backgroundTexture;
        public ContentManager Content { get; private set; } = content;
        public Game Game { get; private set; } = game;

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
