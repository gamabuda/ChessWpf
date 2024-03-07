using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Player
    {
        public Color Color { get; set; }
        public string Name { get; set; }
        public List<IPiece> Pieces { get; set; }
        public List<IPiece> DeadPieces { get; set; }

        public Player(Color color, string name, List<IPiece> pieces)
        {
            Color = color;
            Name = name;

            Pieces = pieces;
            DeadPieces = new List<IPiece>();
        }

        public void EatPiece (IPiece piece)
        {
            DeadPieces.Add(piece);
            Pieces.Remove(piece);
        }
    }
}
