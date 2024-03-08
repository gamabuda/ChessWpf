using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessLibrary
{
    public class Cell: INotifyPropertyChanged
    {
        private State _currentState;
        private IPiece _piece;
        public State CurrentState { get => _currentState; set { _currentState = value; OnPropertyChange(); } }
        public IPiece Piece { get => _piece; set { _piece = value; OnPropertyChange(); } }
        public int HorizontalPosition {  get; private set; }
        public int VerticalPosition { get; private set; }
        public string canMove { get; set; }
 
        public Cell(int Horizontal, int Vertical)
        {
            HorizontalPosition = Horizontal;
            VerticalPosition = Vertical;
            CurrentState = State.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange([CallerMemberName] String propertyName = " ")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PutPiece(IPiece piece)
        {
            Piece = piece;
            CurrentState = piece.State;
        }
    }
}
