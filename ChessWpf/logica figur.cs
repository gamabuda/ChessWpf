using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Chess;
  

namespace Chess
{
    public class Figure
    {
        public int x;
        public int y;

        public Figure(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Pawn : Figure
    {
        public Pawn(int x, int y) : base(x, y) { }

        public bool Move(int newX, int newY)
        {
            if (newX == this.x && (newY == this.y + 1 || (newY == this.y + 2 && this.y == 2)))
            {
                return true;
            }
            return false;
        }
    }


        
    public class Rook : Figure
    {
        public Rook(int x, int y) : base(x, y) { }

        public bool Move(int newX, int newY)
        {
            if ((newX <= this.x + 7 && newY == this.y) ||
                (newX >= this.x - 7 && newY == this.y) ||
                (newX == this.x && newY <= this.y + 7) ||
                (newX == this.x && this.y >= this.y - 7))
            {
                return true;
            }
            return false;
        }
    }

    public class Bishop : Figure
    {
        public Bishop(int x, int y) : base(x, y) { }

        public bool Move(int newX, int newY)
        {
            int constant = 0;
            if (newX - this.x == newY - this.y) { constant = newX - this.x; }
            else if (newX - this.x == this.y - newY) { constant = newX - this.x; }

            if ((newX == this.x + constant && newY == this.y + constant) ||
                (newX == this.x - constant && newY == this.y - constant) ||
                (newX == this.x - constant && newY == this.y + constant) ||
                (newX == this.x + constant && newY == this.y - constant))
            {
                return true;
            }
            return false;
        }
    }

    public class Knight : Figure
    {
        public Knight(int x, int y) : base(x, y) { }


        public bool Move(int newX, int newY)
        {
            if (((newX == this.x + 1 || newX == this.x - 1) && (newY == this.y + 2 || newY == this.y - 2)) ||
                ((newX == this.x + 2 || newX == this.x - 2) && (newY == this.y + 1 || newY == this.y - 1)))
            {
                return true;
            }

            return false;
        }
    }

    public class King : Figure
    {
        public King(int x, int y) : base(x, y) { }

        public bool Move(int newX, int newY)
        {
            int constant = 0;
            if (newX - this.x == newY - this.y && Math.Abs(newX - this.x) == 1) { constant = 1; }
            else if (newX - this.x == this.y - newY && Math.Abs(newX - this.x) == 1) { constant = 1; }

            if ((newX == this.x && (newY == this.y + 1 || newY == this.y - 1) ||
                ((newX == this.x - 1 || newX == this.x + 1) && newY == this.y) ||
                (newX == this.x + constant && newY == this.y + constant) ||
                (newX == this.x - constant && newY == this.y - constant) ||
                (newX == this.x - constant && newY == this.y + constant) ||
                (newX == this.x + constant && newY == this.y - constant)) && (Math.Abs(newX - this.x) == 1 || Math.Abs(newX - this.x) == 0) && (Math.Abs(newY - this.y) == 1 || Math.Abs(newY - this.y) == 0))
            {
                return true;
            }
            return false;
        }
    }

public class Queen : Figure
{
    public Queen(int x, int y) : base(x, y) { }

    public bool Move(int newX, int newY)
    {
        int constant = 0;
        if (newX - this.x == newY - this.y) { constant = newX - this.x; }
        else if (newX - this.x == this.y - newY) { constant = newX - this.x; }
        if ((newX <= this.x + 7 && newY == this.y) ||
            (newX >= this.x - 7 && newY == this.y) ||
            (newX == this.x && newY <= this.y + 7) ||
            (newX == this.x && this.y >= this.y - 7) ||
            (newX == this.x + constant && newY == this.y + constant) ||
            (newX == this.x - constant && newY == this.y - constant) ||
            (newX == this.x - constant && newY == this.y + constant) ||
            (newX == this.x + constant && newY == this.y - constant))
        {
            return true;
        }
        return false;
        }
    }
}