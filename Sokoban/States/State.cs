using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.States
{
    public abstract class State
    {
        public Texture2D BackgroundTexture { get; set; }
        public ContentManager Content { get; set; }
        public Game1 Game { get; protected set; }
        public GraphicsDeviceManager Graphics {  get; protected set; }


        //public abstract void LoadContent(ContentManager content, Texture2D texture);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
