using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf
{
    public class Pawn : ChessFigure
    {
        public bool pawnsFirstMove { get; set; }
        public Pawn(Side side, int[] position) : base(side, position)
        {
            pawnsFirstMove = true;
        }

        public override bool Move(int[] newPos)
        {
            int oldR = Position[0];
            int newR = newPos[0];
            int oldC = Position[1];
            int newC = newPos[1];

            if (SideColor == Side.White)
            {
                if (oldC == newC && oldR - newR == 1)
                {
                    pawnsFirstMove = true;
                    return true;
                }
                if (oldC == newC && oldR - newR == 2 && pawnsFirstMove)
                {
                    pawnsFirstMove = false;
                    return true;
                }
                return false;
            }
            else
            {
                if (oldC == newC && oldR - newR == -1)
                {
                    pawnsFirstMove = true;
                    return true;
                }
                if (oldC == newC && oldR - newR == -2 && pawnsFirstMove)
                {
                    pawnsFirstMove = true;
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