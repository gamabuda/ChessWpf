using ChessLib.Boards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Interfaces
{
    public interface IFigure
    {
        char Figure { get; set; }
        public Cell Position { get; set; }
        string Color { get; set; }
        bool isActive { get; set; }
        public List<(int, int)> CalculateAvailableMoves();

        public bool Move(Cell cell);
        
    }
}
