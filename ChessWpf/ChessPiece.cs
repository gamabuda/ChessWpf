using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWpf
{
    class ChessPiece
    {
        public int x { get; set; }
        public int y { get; set; }
        public virtual bool Move(int newX, int newY)
        {
            return false;
        }
    }

    class Pawn : ChessPiece
    {
        public Pawn(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public override bool Move(int newX, int newY)
        {
            int newwwX = newX - x;
            int newwwY = newY - y;

            if ((newwwX == 0 && newwwY == 1) || (newwwX == 0 && newwwY == 2))
            {
                Console.WriteLine("Пешка ходит на координаты ({0}, {1})", newX, newY);
                x = newX;
                y = newY;
                return true;
            }
            else
            {
                Console.WriteLine("Пешка не может сходить на данные координаты");
                return false;
            }
        }
    }

    class King : ChessPiece
    {
        public King(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public override bool Move(int newX, int newY)
        {
            int newwwX = newX - x;
            int newwwY = newY - y;

            if (newwwX <= 1 && newwwY <= 1)
            {
                Console.WriteLine("Король ходит на координаты ({0}, {1})", newX, newY);
                x = newX;
                y = newY;
                return true;
            }
            else
            {
                Console.WriteLine("Король не может сходить на данные координаты");
                return false;
            }
        }
    }

    class Ferz : ChessPiece
    {
        public Ferz(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public override bool Move(int newX, int newY)
        {
            int newwwX = newX - x;
            int newwwY = newY - y;

            if (newwwX == 0 || newwwY == 0 || newwwX == newwwY)
            {
                Console.WriteLine("Ферзь ходит на координаты ({0}, {1})", newX, newY);
                x = newX;
                y = newY;
                return true;
            }
            else
            {
                Console.WriteLine("Ферзь не может сходить на данные координаты");
                return false;
            }
        }
    }

    class Ladiya : ChessPiece
    {
        public Ladiya(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public override bool Move(int newX, int newY)
        {
            int newwwX = newX - x;
            int newwwY = newY - y;

            if (newwwX == 0 || newwwY == 0)
            {
                Console.WriteLine("Ладья ходит на координаты ({0}, {1})", newX, newY);
                x = newX;
                y = newY;
                return true;
            }
            else
            {
                Console.WriteLine("Ладья не может сходить на данные координаты");
                return false;
            }
        }
    }

    class Slon : ChessPiece
    {
        public Slon(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public override bool Move(int newX, int newY)
        {
            int newwwX = newX - x;
            int newwwY = newY - y;

            if (newwwX == newwwY)
            {
                Console.WriteLine("Слон ходит на координаты ({0}, {1})", newX, newY);
                x = newX;
                y = newY;
                return true;
            }
            else
            {
                Console.WriteLine("Слон не может сходить на данные координаты");
                return false;
            }
        }
    }

    class Kon : ChessPiece
    {
        public Kon(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public override bool Move(int newX, int newY)
        {
            int newwwX = newX - x;
            int newwwY = newY - y;

            if ((newwwX == 2 && newwwY == 1) || (newwwX == 1 && newwwY == 2))
            {
                Console.WriteLine("Конь ходит на координаты ({0}, {1})", newX, newY);
                x = newX;
                y = newY;
                return true;
            }
            else
            {
                Console.WriteLine("Конь не может сходить на данные координаты");
                return false;
            }
        }
    }
}
