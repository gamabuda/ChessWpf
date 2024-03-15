namespace GameLogic
{
    public class Poses
    {
        public int Row { get; }
        public int Col { get; }

        public Poses(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public Player InitilizeColorOfCell()
        {
            if ((Row + Col) % 2 == 0)
                return Player.White;
            else
                return Player.Black;
        }

        public override bool Equals(object? obj)
        {
            return obj is Poses poses &&
                   Row == poses.Row &&
                   Col == poses.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }

        public static bool operator ==(Poses? left, Poses? right)
        {
            return EqualityComparer<Poses>.Default.Equals(left, right);
        }

        public static bool operator !=(Poses? left, Poses? right)
        {
            return !(left == right);
        }

        public static Poses operator +(Poses pos, Directions direct)
        {
            return new Poses(pos.Row + direct.RowDelta, pos.Col + direct.ColDelta);
        }
    }
}
