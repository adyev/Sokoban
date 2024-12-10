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
            return state.GetPressedKeys().Length == 0 ? Keys.None : state.GetPressedKeys()[0];
        }
    }
}
