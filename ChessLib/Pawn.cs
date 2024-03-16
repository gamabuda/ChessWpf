using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Pawn
    {
        public int x { get; set; }
        public int y { get; set; }
        public Pawn(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool CanMove(int x, int y)
        {
            if (this.y == y)
            {
                if (this.x == x)
                {
                    return false;
                }
                else if (Math.Abs(this.x - x) == 1)
                {
                    return true;
                }
                else if (this.x == 1 && Math.Abs(this.x - x) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CanCapture(int x, int y)
        {
            if (Math.Abs(this.x - x) == 1 && Math.Abs(this.y - y) == 1)
            {
                return true;
            }

            return false;
        }
    }
}