using ChessLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Boards
{
    public class Board
    {
        Cell[,] _board;

        public Cell this[int i, int j]
        {
            get { return _board[i, j]; }
            set { _board[i, j] = value; }
        }

        public Board()
        {
            _board = new Cell[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _board[i, j] = new Cell();
                }
            }
        }

        public void UpdateFigures(List<IFigure> figuresList)
        {
            foreach (var figure in figuresList)
            {
                this[figure.Position.VerticalPosition, figure.Position.VerticalPosition].isFilled = true;
            }
        }
    }
}
