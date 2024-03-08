using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public interface IPiece
    {
        Cell CurrentPosition { get; set; }
        Color Color { get; set; }
        State State { get; set; }
        List<(int, int)> AvailableMoves { get; set; }
        void CalculatePossibleMoves(Board board);
    }
}
