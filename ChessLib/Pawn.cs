using System.ComponentModel;

namespace ChessLib
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasMoved { get; set; }
        public bool IsWhite { get; set; }
        public Pawn(int x, int y, bool isWhite)
        {
            X = x;
            Y = y;
            HasMoved = false;
            IsWhite = isWhite;
        }

        public bool IsValidMove(int newX, int newY)
        {
            if (IsWhite)
            {
                return X - newX <= 2 && X - newX > 0 && Y - newY == 0;
            }
            else
            {
                return newX - X <= 2 && newX - X > 0 && Y - newY == 0;
            }
        }

        public void Moved()
        {
            HasMoved = true;
        }
    }
}