using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessLibrary
{
    public class Cell
    {
        private State _currentState;
        private IPiece _piece;
        public State CurrentState { get => _currentState; set { _currentState = value; } }
        public IPiece Piece { get => _piece; set { _piece = value; } }
        public int RowPosition {  get; private set; }
        public int CollumnPosition { get; private set; }
        public bool isActive { get; set; }
 
        public Cell(int Horizontal, int Vertical)
        {
            RowPosition = Horizontal;
            CollumnPosition = Vertical;
            CurrentState = State.Empty;
        }
        public void PutPiece(IPiece piece)
        {
            Piece = piece;
            CurrentState = piece.State;
            piece.CurrentPosition = this;
        }

        public void DeletePiece()
        {
            Piece = null;
            CurrentState = State.Empty;
        }
    }
}
