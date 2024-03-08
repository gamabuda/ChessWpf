using ChessLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public static class PieceLists
    {
        public static List<IPiece> DefaultPieceList = new List<IPiece>()
        {
            new Pawn(new Cell(0, 0), Color.White)
        };
    }
}
