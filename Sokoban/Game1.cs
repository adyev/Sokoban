using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Actors;
using Sokoban.Map.Tiles;
using Sokoban.Map;
using Sokoban.Utils;
using System.Collections.Generic;
using System;
using Sokoban.States;

namespace Sokoban
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Keys PressedKey {  get; set; }
        private Field Field { get; set; }
        static int CorrentLevel { get; set; } = 2;
        static int LevelCount { get; set; } = DirManager.GetLevelCount();
        static SpriteFont Font { get; set; }
        static Vector2 Center { get; set; }
        State GameState { get; set; }
        State CorrentState { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 1600
            };
            Center = new Vector2 { X = _graphics.PreferredBackBufferWidth / 2, Y = _graphics.PreferredBackBufferHeight / 2 };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;            
        }

        protected override void Initialize()
        {
            Field = new Field($"lvl{CorrentLevel}", _graphics);
            PressedKey = Keys.None;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadTextures(Content);
            Font = Content.Load<SpriteFont>("EndText");
            Field.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var keyState = Keyboard.GetState();
            if (Field.IsLvlFinished())
            {
                if (CorrentLevel != LevelCount && PressedKey == Keys.N)
                {
                    CorrentLevel++;
                    Field = new Field($"lvl{CorrentLevel}", _graphics);
                    Field.Initialize();
                }
            }

            if (PressedKey == Keys.R)
            {
                Field = new Field($"lvl{CorrentLevel}", _graphics);
                Field.Initialize();
            }

            if (PressedKey == Keys.None)
            {
                PressedKey = Controls.GetPressedKey(keyState);
                Field.Player.TryMoveTo(Field
                                      .Player
                                      .CorrentTile
                                      .GetTileByDirection(Controls
                                                         .GetMoveDirection(PressedKey))); 
            }
            else if (keyState.IsKeyUp(PressedKey))
                PressedKey = Keys.None;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Field.Draw(_spriteBatch);
            if (Field.IsLvlFinished())
            {
                var text = CorrentLevel == LevelCount ? "End! Press Esc!" : "Nice! Press N for next level!";
                _spriteBatch.DrawString(Font, text, Center, Color.White, 0, Font.MeasureString(text) / 2, 1, SpriteEffects.None, 1);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
