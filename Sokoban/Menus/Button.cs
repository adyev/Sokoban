using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Utils;
using System;

namespace Sokoban.Menus
{
    internal class Button
    {
        string Text {  get; set; }
        Rectangle Outline {  get; set; }
        Texture2D BackgroundTexture { get; set; }
        SpriteFont Font { get; set; }
        public bool IsActive { get; set; } = false;
        float Scale { get; set; } = 1f;
        public EventHandler Click { get; set; }

        public Button(string text, Rectangle outline) 
        {
            Text = text;
            Outline = outline;
            BackgroundTexture = ContentProvider.Textures["Button"];
            Font = ContentProvider.Fonts["Base"];
            if (Outline.Width * 0.8f < Font.MeasureString(Text).X)
                Scale = Outline.Width * 0.8f / Font.MeasureString(Text).X;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var center = new Vector2(Outline.Center.X, Outline.Center.Y);
            var color = IsActive ? Color.White : Color.Gray;
            var origin = Font.MeasureString(Text) / 2;
            origin.X += 5;
            origin.Y -= 2;
            spriteBatch.Draw(BackgroundTexture, Outline, color);
            spriteBatch.DrawString(Font, Text, center, Color.Black, 0, origin, Scale, SpriteEffects.None, 1);
            spriteBatch.DrawString(Font, Text, center, color, 0, Font.MeasureString(Text) / 2, Scale, SpriteEffects.None, 1);
        }
    }
}
