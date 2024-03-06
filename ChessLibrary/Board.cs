using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Board
    {
        Cell[,] _board;

        public Cell this[int Vertical, int Horisontal]
        {
            get
            {
                return _board[Vertical, Horisontal];
            }
            set
            {
                _board[Vertical, Horisontal] = value;
            }
        }

        public Board()
        {
            _board = new Cell[8, 8];
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    _board[i, j] = new Cell(i, j);
                }
            }
        }
    }
}
