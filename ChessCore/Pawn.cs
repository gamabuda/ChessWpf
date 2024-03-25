using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class Pawn : Figure
    {
        private bool isFirstMove;

        public Pawn(int x, int y, ChessColor color) : base(x, y, color)
        {
            isFirstMove = true;
        }

        public override bool CanMove(int newX, int newY)
        {
            int direction = (Color == ChessColor.White) ? -1 : 1;

            if (newX == X && newY == Y)
            {
                return false; // Пешка не может оставаться на месте
            }

            if (newX == X + direction && newY == Y )
            {
                return true; // Пешка может ходить вперед на одну клетку
            }

            if (isFirstMove && newX == X + direction * 2 && newY == Y )
            {
                return true; // Пешка может ходить вперед на две клетки в первый раз
            }
            return false;
        }

        public void Move(int newX, int newY)
        {
            if (CanMove(newX, newY))
            {
                X = newX;
                Y = newY;
                isFirstMove = false; // После первого хода пешка больше не может ходить на две клетки
            }
        }
    }
}
