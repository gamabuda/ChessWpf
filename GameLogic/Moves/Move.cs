namespace GameLogic
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Poses FromPos { get; }
        public abstract Poses ToPos { get; }
        public abstract void Execute(GameField gameField);
    }
}
