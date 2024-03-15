namespace GameLogic
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        public King(Player color)
        {
            Color = color;
        }

        public static readonly Directions[] dirs = new Directions[]
        {
            Directions.Up,
            Directions.Down,
            Directions.Left,
            Directions.Right,
            Directions.UpLeft,
            Directions.DownLeft,
            Directions.UpRight,
            Directions.DownRight
        };

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Poses> MovePoses(Poses from, GameField gameField)
        {
            foreach(Directions dir in dirs)
            {
                Poses to = from + dir;

                if (!GameField.IsInside(to))
                    continue;

                if(gameField.IsEmpty(to) || gameField[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Poses from, GameField gameField)
        {
            foreach(Poses to in MovePoses(from, gameField))
                yield return new NormalMove(from, to);
        }
    }
}
