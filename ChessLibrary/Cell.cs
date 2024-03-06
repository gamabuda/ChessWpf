namespace ChessLibrary
{
    public class Cell
    {
        public State CurrentState { get; set; }
        public Piece Piece { get; set; }
        public int HorizontalPosition {  get; set; }
        public int VerticalPosition { get; set; }

        public Cell(int Horizontal, int Vertical)
        {
            HorizontalPosition = Horizontal;
            VerticalPosition = Vertical;
            CurrentState = State.Empty;
        }

        public void PutPiece(Piece piece)
        {
            Piece = piece;
            CurrentState = piece.State;
        }
    }
}
