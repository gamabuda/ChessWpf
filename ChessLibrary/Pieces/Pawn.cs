using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawm;
        public override Player Color { get; }
        private readonly Direction forward;
        public Pawn(Player color)
        { 
            Color = color;

            if( color == Player.White)
            {
                forward = Direction.North;
            }
            else if( color == Player.Black)
            { 
                forward = Direction.South;
            }
        }
        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        { 
            return Board.isInside(pos) || board.isEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board) 
        { 
            if(!Board.isInside(pos) || board.isEmpty(pos))
                return false;

            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneMovesPos = from + forward;
            if(CanMoveTo(oneMovesPos, board))
            {
                yield return new NormalMove(from, oneMovesPos);

                Position twoMovesPos = oneMovesPos + forward;
                if(!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new NormalMove(from, twoMovesPos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach(Direction dir in new Direction[] { Direction.West, Direction.East,})
            {
                Position to = from + forward + dir;
                if(CanCaptureAt(to, board))
                {
                    yield return new NormalMove(from, to);
                }
            }
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }
        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from, board).Any(move =>
            {
                Piece piece = board[move.To];
                return piece != null && piece.Type == PieceType.King;
            });
        }

    }
}
