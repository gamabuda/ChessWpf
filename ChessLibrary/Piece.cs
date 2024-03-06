using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Piece
    {
        public Point CurrentPoint { get; set; }
        public Color Color { get; set; }
        public State State { get; set; }
    }
}
