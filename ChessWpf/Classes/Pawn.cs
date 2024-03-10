using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf.Classes
{
    public class Pawn : IPiece
    {
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Display { get; set; } = "P";

        public void Move(int row, int column, Tile[,] tiles)
        {
            if (!CanMove(row, column))
                return;
            int tempRow = Row;
            int tempColumn = Column;
            tiles[row, column].Piece = this;
            tiles[tempRow, tempColumn].Piece = null;
            Row = row;
            Column = column;
        }

        public bool CanMove(int newRow, int newColumn)
        {
            if (newRow + 1 == Row && newColumn == Column)
                return true;

            if (newRow + 2 == Row && newColumn == Column && StartRow == Row && StartColumn == Column)
                return true;

            return false;
        }

        public Pawn(int row, int column)
        {
            Row = row;
            Column = column;
            StartRow = row;
            StartColumn = column;
        }
    }
}
