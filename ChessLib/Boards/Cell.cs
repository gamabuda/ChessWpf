using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib.Interfaces;

namespace ChessLib.Boards
{
    public class Cell
    {
        private IFigure figure;
        public IFigure Figure
        {
            get => figure;
            set
            {
                if (!isFilled)
                    figure = value;
                else
                    figure = null;
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public bool isAtacked { get; set; }
        public bool isFilled { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            isAtacked = false;
            isFilled = false;
        }
    }
}
