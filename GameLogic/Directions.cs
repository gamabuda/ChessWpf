namespace GameLogic
{
    public class Directions
    {
        public readonly static Directions Up = new Directions(0, -1);
        public readonly static Directions Down = new Directions(0, 1);
        public readonly static Directions Right = new Directions(-1, 0);
        public readonly static Directions Left = new Directions(1, 0);
        public readonly static Directions UpRight = Up + Right;
        public readonly static Directions DownRight = Down + Right;
        public readonly static Directions UpLeft = Up + Left;
        public readonly static Directions DownLeft = Down + Left;

        public int ColDelta { get; }
        public int RowDelta { get; }

        public Directions(int colDelta, int rowDelta)
        {
            ColDelta = colDelta;
            RowDelta = rowDelta;
        }

        public static Directions operator +(Directions a, Directions b)
        {
            return new Directions(a.RowDelta + b.RowDelta, a.ColDelta + b.ColDelta);
        }

        public static Directions operator *(int scalar, Directions direct)
        {
            return new Directions(scalar * direct.RowDelta, scalar * direct.ColDelta);
        }
    }
}
