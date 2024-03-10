using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessWpf.Classes
{
    public class Tile
    {
        public Button Button { get; set; }
        public IPiece Piece
        {
            get
            {
                return _piece;
            }
            set
            {
                _piece = value;
                Button.Content = _piece is null ? "" : _piece.Display;
                if (!(_piece is null))
                {
                    _piece.Row = Row;
                    _piece.Column = Column;
                }
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }

        private IPiece _piece;
        public Tile(Button button, int row, int column)
        {
            Button = button;
            Row = row;
            Column = column;
            button.Content = Piece?.Display;
        }
    }
}
