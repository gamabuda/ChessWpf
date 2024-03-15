namespace GameLogic
{
    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.Bishop;
        public override Player Color { get; }

        public Bishop(Player color)
        {
            Color = color;
        }

        private static readonly Directions[] dirs = new Directions[]
        {
            Directions.UpLeft,
            Directions.UpRight,
            Directions.DownRight,
            Directions.DownLeft
        };

        public override IEnumerable<Move> GetMoves(Poses from, GameField gameField)
        {
            return MovePositionsInDirs(from, gameField, dirs).Select(to => new NormalMove(from, to));
        }

        public override Piece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
