using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Rook : Figure
    {
        public Rook(int X, int Y) : base(X, Y)
        {

        }

        public bool Move(int newX, int newY)
        {
            return (newX == x || newY == y);
        }
    }
}
