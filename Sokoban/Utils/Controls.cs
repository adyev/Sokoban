using Microsoft.Xna.Framework.Input;

namespace Sokoban.Utils
{
    internal static class Controls
    {
        public static Directions GetMoveDirection(Keys key)
        {
            return key switch
            {
                Keys.Up => Directions.UP,
                Keys.Down => Directions.DOWN,
                Keys.Right => Directions.RIGHT,
                Keys.Left => Directions.LEFT,
                _ => Directions.NONE,
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
            if (state.IsKeyDown(Keys.N))
                return Keys.N;
            if (state.IsKeyDown(Keys.R))
                return Keys.R;
            return Keys.None;
        }
    }
}
