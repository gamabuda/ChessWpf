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
        public Cell Position { get; set; }
        public Cell StartPosition { get; set; }
        public Color Color { get; set; }
        public bool isActive { get; set; }
        public List<(int, int)> AvailableMoves { get; set; }

        private (int, int)[] Directions4Move = new (int, int)[] 
        { 
            (0, 1), 
            (0, -1) 
        };

        public Pawn(Cell position, Color color)
        {
            Position = position;
            StartPosition = position;
            Color = color;
            isActive = true;
        }

        public List<(int, int)> CalculateAvailableMoves(Board board)
        {
            List<(int, int)> moves = new List<(int, int)>();
            foreach (var direction in Directions4Move)
            {
                int newVertical = Position.VerticalPosition + direction.Item1;
                int newHorizontal = Position.HorizontalPosition + direction.Item2;

                if (board[newVertical, newHorizontal].isFilled == false)
                {
                    moves.Add((newVertical, newHorizontal));
                }
            }
            if (Position == StartPosition)
            {
                moves.Add((Position.VerticalPosition + 2, Position.HorizontalPosition));
            }
            return moves;
        }
    }
}
