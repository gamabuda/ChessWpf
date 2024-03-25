using System.Drawing;

namespace ChessCore
{
    public enum ChessColor
    {
        White,
        Black
    }
    public abstract class Figure
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public ChessColor Color { get; protected set; }
        public int x { get; set; }
        public int y { get; set; }

        public Figure(int x, int y, ChessColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public abstract bool CanMove(int newX, int newY);
    }

}
