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
        public List<(int, int)> AvailableMoves { get; set; }
        private List<(int, int)> PossibleDirections = new List<(int, int)>
        {
                (1, 0),
        };
        public Func<int, int, bool>[] MoveConditions { get; set; } = new Func<int, int, bool>[0];


        public Pawn(Cell currentPosition, Color color)
        {
            AvailableMoves = new List<(int, int)>();
            CurrentPosition = currentPosition;
            StartPosition = CurrentPosition;
            Color = color;
            State = color == Color.Black ? State.BlackPawn : State.WhitePawn;
        }

        public void CalculatePossibleMoves(Board board)
        {
            AvailableMoves.Clear();
            int k = Color == Color.White ? -1 : 1;
            foreach (var direction in PossibleDirections)
            {
                int newRow = CurrentPosition.RowPosition + direction.Item1 * k;
                int newCollumn = CurrentPosition.CollumnPosition + direction.Item2 * k;
                if (board[newRow, newCollumn].CurrentState == State.Empty)
                {
                    AvailableMoves.Add((newRow, newCollumn));
                }
            }
            if (CurrentPosition.RowPosition == StartPosition.RowPosition)
            {
                AvailableMoves.Add((CurrentPosition.RowPosition + (2 * k), CurrentPosition.CollumnPosition));
            }
        }
    }
}
