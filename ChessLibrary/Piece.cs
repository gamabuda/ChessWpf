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
        Cell CurrentPoint { get; set; }
        Cell DefaultPoint { get; set; }
        Color Color { get; set; }
        State State { get; set; }
    }
}
