namespace GameLogic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static IEnumerable<Poses> PotentialToPoses(Poses from)
        {
            foreach (Directions vDir in new Directions[] { Directions.Up, Directions.Down })
            {
                foreach (Directions hDir in new Directions[] { Directions.Left, Directions.Right })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2* hDir + hDir;
                }
            }
        }

        private IEnumerable<Poses> MovePoses(Poses from, GameField gameField)
        {
            return PotentialToPoses(from).Where(pos => GameField.IsInside(pos) 
            && (gameField.IsEmpty(pos) 
            || gameField[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Poses from, GameField gameField)
        {
            return MovePoses(from, gameField).Select(to => new NormalMove(from, to));
        }
    }
}
