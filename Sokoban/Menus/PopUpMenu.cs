using Microsoft.Xna.Framework;

namespace Sokoban.Menus
{
    internal abstract class PopUpMenu
    {
        public float MenuHeight { get; set; }
        public float MenuWidth { get; set; }
        public MenuLayout Layout { get; set; }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
