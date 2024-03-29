using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class GameState
    {
        public Board Board { get;}
        public Player CurrentPlayer { get; private set; }
        public Result Result { get; private set; } = null;
        public GameState(Board board, Player currentPlayer)
        {
            Board = board;
            CurrentPlayer = currentPlayer;
        }
        public IEnumerable <Move> LegalMovesForpieces(Position pos)
        {
            if(Board.isEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            IEnumerable<Move> moveCandidates =  piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.isLegal(Board));
        }
        public void MakeMove(Move move) 
        {
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
            CheckForGameOver();
        }
        public IEnumerable<Move> AllLegalPositionsFor(Player player) 
        {
            IEnumerable<Move> moveCanditates = Board.PiecePositionsFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });
            return moveCanditates.Where(move => move.isLegal(Board));
        }

        private void CheckForGameOver()
        {
            if(!AllLegalPositionsFor(CurrentPlayer).Any())
            {
                if(Board.IsInCheck(CurrentPlayer)) 
                {
                    Result = Result.Win(CurrentPlayer.Opponent());
                }
                else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
        }
        public bool isGameOver()
        {
            return Result != null;
        }
    }
}
