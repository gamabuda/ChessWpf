namespace GameLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; } = false;

        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Poses from, GameField gameField);

        protected IEnumerable<Poses> MovePositionsInDir(Poses from, GameField gameField, Directions dir)
        {
            for (Poses pos = from + dir; GameField.IsInside(pos); pos += dir)
            {
                if (gameField.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = gameField[pos];

                if(piece.Color != Color)
                {
                    yield return pos;
                }

                yield break;
            }
        }

        protected IEnumerable<Poses> MovePositionsInDirs(Poses from, GameField gameField, Directions[] dirs)
        {
            return dirs.SelectMany(dir => MovePositionsInDirs(from, gameField, dirs));
        }
    }
}
