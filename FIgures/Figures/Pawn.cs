using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessWpf
{
    public class Pawn : ChessFigure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasMoved { get; set; }

        public Pawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
            HasMoved = false;
        }

        public bool IsValidMove(int newX, int newY, bool HasMoved)
        {
            if (!HasMoved)
            {
                return (Math.Abs(X - newX) < 1 && Math.Abs(Y - newY) <= 2);
            }
            else
            {
                return (Math.Abs(X - newX) < 1 && Math.Abs(Y - newY) <= 1);
            }
        }

        public void MovedMark()
        {
            HasMoved = true;
        }
    }
}

