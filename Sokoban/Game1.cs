using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Map;
using Sokoban.Utils;
using System;
using Sokoban.States;

namespace Sokoban
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public int CorrentLevel { get; set; } = 1;
        GameState GameState { get; set; }
        MenuState MenuState { get; set; }
        State CorrentState { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 1600
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;            
        }

        protected override void Initialize()
        {            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadResources(Content);
            GameState = new GameState(this, _graphics);
            MenuState = new MenuState(this);
            CorrentState = MenuState;

        }

        protected override void Update(GameTime gameTime)
        {
            CorrentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            CorrentState.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetGameState(object sender, EventArgs e)
        {
            CorrentState = GameState;
        }

        public void SetMenuState(object sender, EventArgs e)
        {
            CorrentState = MenuState;
        }
        public void ExitEvent(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
