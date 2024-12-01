using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Utils
{
    internal static class Controls
    {
        public static Vector2 GetMoveDirection(Keys key)
        {
            return key switch
            {
                Keys.Up => new Vector2(0, -1f),
                Keys.Down => new Vector2(0, 1f),
                Keys.Right => new Vector2(1f, 0),
                Keys.Left => new Vector2(-1f, 0),
                _ => new Vector2(0, 0),
            };
        }
        public static Keys GetPressedKey(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Up))
                return Keys.Up;
            if (state.IsKeyDown(Keys.Down))
                return Keys.Down;
            if (state.IsKeyDown(Keys.Right))
                return Keys.Right;
            if (state.IsKeyDown(Keys.Left))
                return Keys.Left;
            return Keys.None;
        }
    }
}
