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
        Board board;
        Player[] players;

        public void InitializeBoard()
        {
            board = new Board();
            board.PlacePieces(PieceLists.DefaultPieceList);
        }

        private void InitPlayers()
        {
            players = new Player[2]
            {
                new Player(Color.White, "WhitePlayer", PieceLists.DefaultPieceList),
                new Player(Color.Black, "BlackPlayer", PieceLists.DefaultPieceList)
            };
        }
    }
}
