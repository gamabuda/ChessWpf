using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Horse : Figure
    {
        public Horse(int X, int Y) : base(X, Y)
        {

        }

        public bool Move(int newX, int newY)
        {
            return ((Math.Abs(x - newX) == 2 && Math.Abs(y - newY) == 1) || (Math.Abs(x - newX) == 1 && Math.Abs(y - newY) == 2));
        }
    }
}
