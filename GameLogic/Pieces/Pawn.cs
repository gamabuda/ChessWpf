using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace GameLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Directions forward;

        public Pawn(Player color)
        {
            Color = color;

            if(color == Player.White)
                forward = Directions.Up;
            else if (color == Player.Black)
                forward = Directions.Down;
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMove(Poses pos, GameField gameField)
        {
            return GameField.IsInside(pos) && gameField.IsEmpty(pos);
        }

        private bool CanCapture(Poses pos, GameField gameField)
        {
            if(!GameField.IsInside(pos) || gameField.IsEmpty(pos)) 
                return false;
            return gameField[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Poses from, GameField gameField)
        {
            Poses oneMovePos = from + forward;

            if(CanMove(oneMovePos, gameField))
            {
                yield return new NormalMove(from, oneMovePos);

                Poses twoMovePos = oneMovePos + forward;

                if(!HasMoved && CanMove(twoMovePos, gameField))
                {
                    yield return new NormalMove(from, twoMovePos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMove(Poses from, GameField gameField)
        {
            foreach(Directions dir in new Directions[] {Directions.Left, Directions.Right })
            {
                Poses to = from + dir + forward;

                if(CanCapture(to, gameField))
                {
                    yield return new NormalMove(from, to);
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Poses from, GameField gameField)
        {
            return ForwardMoves(from, gameField).Concat(DiagonalMove(from, gameField));
        }
    }
}
