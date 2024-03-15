namespace GameLogic
{
    public class Rook : Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override Player Color { get; }

        public Rook(Player color)
        {
            Color = color;
        }

        private static readonly Directions[] dirs = new Directions[]
        {
            Directions.Up,
            Directions.Down,
            Directions.Right,
            Directions.Left
        };

        public override Piece Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Poses from, GameField gameField)
        {
            return MovePositionsInDirs(from, gameField, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
