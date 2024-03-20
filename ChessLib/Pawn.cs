namespace ChessLib
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasMoved { get; set; }
        public Colorsquare Color { get; set; }

        public Pawn(int x, int y, Colorsquare color)
        {
            X = x;
            Y = y;
            HasMoved = false;
            Color = color;
        }

        public bool CanMove(int newX, int newY)
        {
            if (newX <= X)
            {
                return false;
            }

            if (Color == Colorsquare.White && newX > X)
            {
                if (newY == Y && newX - X <= 1 && !HasMoved)
                {
                    return true;
                }

                if (newY == Y  && newX - X <= 2 && !HasMoved)
                {
                    return true;
                }
            }

            if (Color == Colorsquare.Black && newX > X)
            {
                if (newY == Y && newX - X <= 1 && !HasMoved)
                {
                    return true;
                }

                if (newY == Y && newX - X <= 2 && !HasMoved)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanCapture(int newX, int newY)
        {
            if (Math.Abs(X - newX) == 1 && Math.Abs(Y - newY) == 1)
            {
                return false;
            }

            return false;
        }
    }

    public enum Colorsquare
    {
        White,
        Black
    }
}