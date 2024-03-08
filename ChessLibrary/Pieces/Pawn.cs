using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Pieces
{
    public class Pawn : IPiece
    {
        public Cell StartPosition { get; set; }
        public Cell CurrentPosition { get; set; }
        public Color Color { get; set; }
        public State State { get; set; }
        public bool isActive { get; set; }
        public List<(int, int)> AvailableMoves { get; set; }
        private List<(int, int)> PossibleDirections = new List<(int, int)>
        {
                (1, 0),
        };
        public Func<int, int, bool>[] MoveConditions { get; set; } = new Func<int, int, bool>[0];


        public Pawn(Cell currentPosition, Color color)
        {
            CurrentPosition = currentPosition;
            StartPosition = currentPosition;
            Color = color;
            State = color == Color.Black ? State.BlackPawn : State.WhitePawn;
        }

        public List<(int, int)> CalculatePossibleMoves(Board board)
        {
            List<(int, int)> moves = new List<(int, int)>();
            foreach (var direction in PossibleDirections)
            {
                int newVertical = CurrentPosition.VerticalPosition + direction.Item1;
                int newHorizontal = CurrentPosition.HorizontalPosition + direction.Item2;
                if (board[newVertical, newHorizontal].CurrentState == State.Empty)
                {
                    moves.Add((newVertical, newHorizontal));
                }
            }
            if (CurrentPosition == StartPosition)
            {
                moves.Add((CurrentPosition.VerticalPosition + 2, CurrentPosition.HorizontalPosition));
            }
            return moves;
        }
    }
}
