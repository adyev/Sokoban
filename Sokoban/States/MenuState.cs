using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Menus;
using Sokoban.Utils;
using System;

namespace Sokoban.States
{
    internal class MenuState : State
    {
        MenuLayout Layout {  get; set; }
        private Keys PressedKey { get; set; } = Keys.None;
        int CorrentButtonIndex { get; set; } = 0;

        public MenuState(Game1 game) 
        {
            Game = game;
            Layout = new MainManuLayout(Game);
            Layout.Buttons[CorrentButtonIndex].IsActive = true;
        }


        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Enter) && Layout.Buttons[CorrentButtonIndex].Click != null)
                Layout.Buttons[CorrentButtonIndex].Click.Invoke(this, new EventArgs());
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();
            var keyState = Keyboard.GetState();
            

            if (PressedKey == Keys.None)
            {
                PressedKey = Controls.GetPressedKey(keyState);
                if (PressedKey == Keys.Up && CorrentButtonIndex > 0)
                {
                    Layout.Buttons[CorrentButtonIndex].IsActive = false;
                    CorrentButtonIndex--;
                    Layout.Buttons[CorrentButtonIndex].IsActive = true;
                }
                if (PressedKey == Keys.Down && CorrentButtonIndex < Layout.Buttons.Count - 1)
                {
                    Layout.Buttons[CorrentButtonIndex].IsActive = false;
                    CorrentButtonIndex++;
                    Layout.Buttons[CorrentButtonIndex].IsActive = true;
                }
            }
            else if (keyState.IsKeyUp(PressedKey))
                PressedKey = Keys.None;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Layout.Draw(spriteBatch);
        }

    }
}
