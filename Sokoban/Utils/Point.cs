namespace Sokoban.Utils
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x; Y = y;
        }

        public static Point operator +(Point a) => a;
        public static Point operator -(Point a) => new(-a.X, -a.Y);
        public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
        public static Point operator -(Point a, Point b) => a + (-b);

        public override string ToString() => $"X: {X}, Y: {Y}";
    }
}