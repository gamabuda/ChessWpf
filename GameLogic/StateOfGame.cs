namespace GameLogic
{
    public class StateOfGame
    {
        public GameField GameField { get; }
        public Player CurrentPlayer { get; private set; }

        public StateOfGame(Player player, GameField gameField)
        {
            CurrentPlayer = player;
            GameField = gameField;
        }

        public IEnumerable<Move> LegalovesForPiece(Poses pos)
        {
            if (GameField.IsEmpty(pos) || GameField[pos].Color != CurrentPlayer)
                return Enumerable.Empty<Move>();

            Piece piece = GameField[pos];
            return piece.GetMoves(pos, GameField);
        }

        public void Makeove(Move move)
        {
            move.Execute(GameField);
            CurrentPlayer = CurrentPlayer.Opponent();
        }
    }
}
