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
    }
}
