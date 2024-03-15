namespace GameLogic
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        public Queen(Player color)
        {
            Color = color;
        }

        private static readonly Directions[] dirs = new Directions[]
        {
            Directions.Up,
            Directions.Down,
            Directions.Right,
            Directions.Left,
            Directions.UpLeft,
            Directions.UpRight,
            Directions.DownRight,
            Directions.DownLeft
        };

        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Poses from, GameField gameField)
        {
            return MovePositionsInDirs(from, gameField, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
