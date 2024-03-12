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

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    _board[i, j] = new Cell(i, j);
                }
            }
        }

        //public void UpdateFigures(List<IFigure> figuresList)
        //{
        //    foreach (var figure in figuresList)
        //    {
        //        this[figure.Position.Row, figure.Position.Column].isFilled = true;
        //    }
        //}

        public void UpdateFigure(IFigure figure)
        {
            this[figure.Position.Row, figure.Position.Column].isFilled = true;
        }
    }
}
