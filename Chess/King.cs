using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class king : Figure
    {
        public king(int X, int Y) : base(X, Y)
        {

        }

        public bool Move(int newX, int newY)
        {
            return ((newX == x + 1 || newX == x - 1 || newX == x) && (newY == y + 1 || newY == y - 1 || newY == y));
        }
    }
}
