using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }
        public Knight(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            foreach(Direction vdir in new Direction[] {Direction.North, Direction.South})
            { 
                foreach(Direction hdir in new Direction[] {Direction.West, Direction.East})
                {
                    yield return from + 2 * vdir + hdir;
                    yield return from + 2 * hdir + vdir;
                }
            }
        }
        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos => Board.isInside(pos)
                && (board.isEmpty(pos) || board[pos].Color != Color));
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from, board).Select(to => new NormalMove(from, to));
        }

    }
}
