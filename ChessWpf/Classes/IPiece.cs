using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf.Classes
{
    public interface IPiece
    {
        int Row { get; set; }
        int Column { get; set; }
        string Display { get; set; }
        public void Move(int row, int column, Tile[,] tiles);
    }
}
