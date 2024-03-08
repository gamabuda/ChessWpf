using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Board
    {
        Cell[,] _board;
        List<IPiece> _pieces;
        Player[] _players;

        public Cell this[int Row, int Collumn]
        {
            get
            {
                if(Row < 8 && Collumn < 8 && Row > -1 && Collumn > -1)
                return _board[Row, Collumn];
                return new Cell(-1, -1);
            }
            set
            {
                _board[Row, Collumn] = value;
            }
        }

        public Board(Player player1, Player player2)
        {
            _players = new Player[2] { player1, player2 };
            _pieces = _players[0].Pieces.Union(_players[1].Pieces).ToList();
            _board = new Cell[8, 8];
            
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    _board[j, i] = new Cell(j, i);
                }
            }
        }

        public void PlacePieces()
        {
            foreach (var piece in _pieces)
            {
                Cell cell = this[piece.CurrentPosition.RowPosition, piece.CurrentPosition.CollumnPosition];
                cell.CurrentState = piece.State;
                cell.PutPiece(piece);
            }
        }

        public IEnumerator<Cell> GetEnumerator() 
        {
            foreach(var cell in _board)
            {
                yield return cell;
            }        
        }
    }
}
