using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban.Menus
{
    internal abstract class MenuLayout
    {
        protected Texture2D BackgroundTexture {  get; set; }
        public List<Button> Buttons { get; set; }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 1f);
            foreach (var button in Buttons)
            {
                button.Draw(spriteBatch);
            }
        }
    }
}
