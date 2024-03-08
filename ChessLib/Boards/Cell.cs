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
                if (isFilled)
                    figure = value;
                else
                    figure = null;
            }
        }

        public int HorizontalPosition { get; private set; }
        public int VerticalPosition { get; private set; }
        public bool isAtacked { get; set; }
        public bool isFilled { get; set; }

        public Cell()
        {
            isAtacked = false;
            isFilled = false;
        }
    }
}
