namespace ChessLib
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasMoved { get; set; }

        public Pawn(int x, int y)
        {
            X = x;
            Y = y;
            HasMoved = false;
        }

        public bool IsValidMove(int newX, int newY)
        {
            if (!HasMoved && newX > X)
            {
                return Math.Abs(X - newX) <= 2 && Math.Abs(Y - newY) ==0;
            }
            else if (!HasMoved && newX > X)
            {
                return Math.Abs(X - newX) <= 1 && Math.Abs(Y - newY) <= 0;
            }
            else if (!HasMoved && newX <= X)
            {
                return Math.Abs(X - newX) <= 2 && Math.Abs(Y - newY) == 0;
            }
            else
            {
                return Math.Abs(X - newX) <= 1 && Math.Abs(Y - newY) <= 0;
            }
        }

        public void Moved()
        {
            HasMoved = true;
        }
    }
}