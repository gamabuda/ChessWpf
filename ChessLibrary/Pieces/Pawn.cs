using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Pieces
{
    public class Pawn : IPiece
    {
        public Cell CurrentPoint { get; set; }
        public Cell DefaultPoint { get; set; }
        public Color Color { get; set; }
        public State State { get; set; }

        public List<Direction> PossibleDirections { get; private set; } = new List<Direction>()
        {

        };
    }
}
