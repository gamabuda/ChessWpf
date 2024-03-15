using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf
{
    public class ChessFigure
    { 
        public enum Side { White, Black }

        public Side SideColor { get; }
        public int[] Position { get; set; }

        public ChessFigure(Side side, int[] position)
        {
            SideColor = side;
            Position = position;
        }

        public virtual bool Move(int[] newPos)
        {
            Position = newPos;
            return true;
        }
    }
}