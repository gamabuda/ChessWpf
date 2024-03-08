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
        public Cell Position { get; set; }
        Color Color { get; set; }
        bool isActive { get; set; }
        public List<(int, int)> CalculateAvailableMoves(Board board);
    }
}
