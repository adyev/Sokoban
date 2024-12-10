using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Menus;
using Sokoban.Utils;
using System;

namespace Sokoban.States
{
    internal class MenuState : State
    {
        public MenuLayout Layout {  get; set; }
        int CorrentButtonIndex { get; set; } = 0;
        SoundEffect MoveSoundEffect { get; set; }
        SoundEffect SelectSoundEffect { get; set; }

        public MenuState(Game1 game) 
        {
            Game = game;
            Layout = new MainMenuLayout(Game);
            Layout.Buttons[CorrentButtonIndex].IsActive = true;
            MoveSoundEffect = ContentProvider.Sounds["MenuSelect"];
            SelectSoundEffect = ContentProvider.Sounds["MenuSelected"];
        }


        public override void Update(GameTime gameTime)
        {
            var keyState = Keyboard.GetState();
            if (Game.PressedKey == Keys.None)
            {
                Game.PressedKey = Controls.GetPressedKey(keyState);
                if (Game.PressedKey == Keys.Enter && Layout.Buttons[CorrentButtonIndex].Click != null)
                {
                    SelectSoundEffect.Play();
                    Layout.Buttons[CorrentButtonIndex].Click.Invoke(this, new EventArgs());
                }

                if (Game.PressedKey == Keys.Escape && Layout is MainMenuWithContinueLayout)
                    Game.ContinueGame(this, new EventArgs());

                if (Game.PressedKey == Keys.Up && CorrentButtonIndex > 0)
                {
                    Layout.Buttons[CorrentButtonIndex].IsActive = false;
                    CorrentButtonIndex--;
                    Layout.Buttons[CorrentButtonIndex].IsActive = true;
                    MoveSoundEffect.Play();
                }
                if (Game.PressedKey == Keys.Down && CorrentButtonIndex < Layout.Buttons.Count - 1)
                {
                    Layout.Buttons[CorrentButtonIndex].IsActive = false;
                    CorrentButtonIndex++;
                    Layout.Buttons[CorrentButtonIndex].IsActive = true;
                    MoveSoundEffect.Play();
                }
            }
            else if (keyState.IsKeyUp(Game.PressedKey))
                Game.PressedKey = Keys.None;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Layout.Draw(spriteBatch);
        }

    }
}
