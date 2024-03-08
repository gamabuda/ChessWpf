using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Game
    {
        public Board board { get; set; }
        Player[] players;
        public IPiece CurrentActivePiece { get; set; }
        public Cell CurrentActiveCell { get; set; }

        public Game()
        {
            players = new Player[2]
            {
                new Player(Color.White, "WhitePlayer", PieceLists.DefaultPieceList),
                new Player(Color.Black, "BlackPlayer", PieceLists.DefaultPieceList)
            };
        }

        public void StartGame()
        {
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            board = new Board(players[0], players[1]);
            board.PlacePieces();
        }

        public void DoInactive()
        {
            CurrentActiveCell.DeletePiece();
            CurrentActiveCell = null;
            CurrentActivePiece = null;
            foreach(var cell in board)
            {
                if(cell.CurrentState == State.CanMoveCell)
                {
                    cell.CurrentState = State.Empty;
                }
            }
        }
    }
}
