using ChessLib.Boards;
using ChessLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Figures
{
    public class Pawn : IFigure
    {
        public char Figure { get; set; } = '♙';
        public Cell Position { get; set; }


        public string Color { get; set; }
        public bool isActive { get; set; }
        public List<(int, int)> AvailableMoves { get; set; }

        private (int, int)[] Directions4Move = new (int, int)[] 
        { 
            (1, 0) 
        };

        public Pawn(Cell position, string color)
        {
            Position = position;
            Color = color;
            isActive = true;
        }

        public List<(int, int)> CalculateAvailableMoves()
        {
            List<(int, int)> moves = new List<(int, int)>();

            foreach (var direction in Directions4Move)
            {
                int newRow;
                if (Color == "white")
                    newRow = Position.Row - direction.Item1;
                else
                    newRow = Position.Row + direction.Item1;

                if (Position.isFilled == true)
                {
                    moves.Add((newRow, Position.Column));
                }
            }

            if ((Position.Row == 2 || Position.Row == 7) && (Position.Column == 1 || Position.Column == 2 || Position.Column == 3 || Position.Column == 4 || Position.Column == 5 || Position.Column == 6 || Position.Column == 7 || Position.Column == 8))
            {
                if (Color == "white")
                    moves.Add((Position.Row - 2, Position.Column));
                else
                    moves.Add((Position.Row + 2, Position.Column));
            }

            return moves;
        }

        public bool Move(Cell cell)
        {
            List<(int, int)> moves = CalculateAvailableMoves();

            foreach (var move in moves)
            {
                if(move.Item1 == cell.Row && move.Item2 == cell.Column)
                {
                    Position.Row = move.Item1;
                    Position.Column = move.Item2;
                    return true;
                }
            }

            return false;
        }
    }
}
