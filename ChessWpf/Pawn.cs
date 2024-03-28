using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf
{
    public class Pawn : ChessPiece
    {

        public Pawn(Color color, int[] position) : base(color, position)
        {
        }

        public override bool Move(int[] newPosition)
        {
            int oldRow = Position[0];
            int newRow = newPosition[0];
            int oldCol = Position[1];
            int newCol = newPosition[1];

            if (PieceColor == Color.White)
            {
                if (oldCol == newCol && oldRow - newRow == 1)
                {
                    isFirstMove = true;
                    return true;
                }
                if (oldCol == newCol && oldRow - newRow == 2 && isFirstMove)
                {
                    isFirstMove = false;
                    return true;
                }
                return false;
            }
            else
            {
                if (oldCol == newCol && oldRow - newRow == -1)
                {
                    isFirstMove = true;
                    return true;
                }
                if (oldCol == newCol && oldRow - oldRow == -2 && isFirstMove)
                {
                    isFirstMove = true;
                    return true;
                }
                return false;
            }
        }
        public override string ToString()
        {
            return "Pawn";
        }
    }
}
