using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chess.ChessPiece;

namespace Chess
{
    public class Elephant : Figure
    {
        public Elephant(int X, int Y) : base(X, Y)
        {

        }

        public bool Move(int newX, int newY)
        {
            return (Math.Abs(newX - x) == Math.Abs(newY - y));
        }
    }
}
