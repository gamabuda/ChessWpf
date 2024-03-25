using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class ChessSquare
    {
        public int Row { get; }
        public int Column { get; }

        public ChessSquare(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
