using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Map;
using Sokoban.Utils;

namespace Sokoban.States
{
    internal class GameState : State
    {
        Field Field {  get; set; }
        int CorrentLevel { get; set; }
        static int LevelCount { get; set; } = DirManager.GetLevelCount();
        private Keys PressedKey { get; set; }
        static SpriteFont Font { get; set; }
        static Vector2 Center { get; set; }

        public GameState(Game1 game, GraphicsDeviceManager graphics) 
        { 
            Game = game;
            Graphics = graphics;
            Center = new Vector2 { X = graphics.PreferredBackBufferWidth / 2, Y = graphics.PreferredBackBufferHeight / 2 };
            Field = new Field($"lvl{Game.CorrentLevel}", graphics);
            Field.Initialize();
            Font = TextureManager.Fonts["Base"];
            CorrentLevel = Game.CorrentLevel;
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();
            var keyState = Keyboard.GetState();
            if (Field.IsLvlFinished())
            {
                if (CorrentLevel != LevelCount && PressedKey == Keys.N)
                {
                    CorrentLevel++;
                    Field = new Field($"lvl{CorrentLevel}", Graphics);
                    Field.Initialize();
                }
            }

            if (PressedKey == Keys.R)
            {
                Field = new Field($"lvl{CorrentLevel}", Graphics);
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
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Field.Draw(spriteBatch);
            if (Field.IsLvlFinished())
            {
                var text = CorrentLevel == LevelCount ? "End! Press Esc!" : "Nice! Press N for next level!";
                spriteBatch.DrawString(Font, text, Center, Color.White, 0, Font.MeasureString(text) / 2, 1, SpriteEffects.None, 1);
            }
        }
    }
}
