using Microsoft.Xna.Framework;
using Sokoban.Utils;

namespace Sokoban.Menus
{
    internal class MainMenuLayout : MenuLayout
    {
        public MainMenuLayout (Game1 game)
        {
            BackgroundTexture = ContentProvider.Textures["MenuBG"];
            Buttons =
            [
                new Button("New game", new Rectangle(600, 100, 400, 100)),
                new Button("Liderboard", new Rectangle(600, 250, 400, 100)),
                new Button($"Settings", new Rectangle(600, 400, 400, 100)),
                new Button("Exit", new Rectangle(600, 550, 400, 100)),
            ];
            Buttons[0].Click += game.StartNewGame;
            Buttons[3].Click += game.ExitEvent;
        }
    }
}
