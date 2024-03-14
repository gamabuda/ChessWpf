using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf
{
    public class ChessPiece
    {
        public bool isFirstMove {  get; set; }
        public enum Color
        {
            White,
            Black
        }

        public Color PieceColor { get; }
        public int[] Position { get; set; }

        public ChessPiece(Color color, int[] position)
        {
            PieceColor = color;
            Position = position;
            isFirstMove = true;
        }

        public virtual bool Move(int[] newPosition)
        {
            Position = newPosition;
            Console.WriteLine($"Piece moved to {newPosition}");
            return true;
        }
    }
}
