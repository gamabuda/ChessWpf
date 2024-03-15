namespace GameLogic
{
    public class GameField
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Poses pos]
        {
            get { return this[pos.Row, pos.Col]; }
            set { this[pos.Row, pos.Col] = value; }
        }

        public static GameField Initial()
        {
            GameField gameField = new GameField();
            gameField.AddStartPosesOfPieces();
            return gameField;
        }

        private void AddStartPosesOfPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[0, 1] = new Knight(Player.Black);
            this[0, 6] = new Knight(Player.Black);

            this[0, 2] = new Bishop(Player.Black);
            this[0, 5] = new Bishop(Player.Black);

            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);

            for(int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(Player.Black);
                this[6, i] = new Pawn(Player.White);
            }

            this[7, 0] = new Rook(Player.White);
            this[7, 7] = new Rook(Player.White);

            this[7, 1] = new Knight(Player.White);
            this[7, 6] = new Knight(Player.White);

            this[7, 2] = new Bishop(Player.White);
            this[7, 5] = new Bishop(Player.White);

            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
        }

        public static bool IsInside(Poses pos)
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Col >= 0 && pos.Col < 8;
        }

        public bool IsEmpty(Poses pos)
        {
            return this[pos] == null;
        }
    }
}
