namespace GameLogic
{
    public class NormalMove : Move
    {
        public override MoveType Type => MoveType.Normal;
        public override Poses FromPos { get; }
        public override Poses ToPos { get; }

        public NormalMove(Poses from, Poses to)
        {
            FromPos = from;
            ToPos = to;
        }
        public override void Execute(GameField gameField)
        {
            Piece piece = gameField[FromPos];
            gameField[ToPos] = piece;
            gameField[FromPos] = null;
            piece.HasMoved = true;
        }
    }
}
