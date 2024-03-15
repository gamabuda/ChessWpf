using System.Windows.Media;
using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using GameLogic;

namespace ChessWpf
{
    public static class Images
    {
        private static ImageSource LoadImage(string filepath)
        {
            return new BitmapImage(new Uri(filepath, UriKind.Relative));
        }

        private static readonly Dictionary<PieceType, ImageSource> whitepiecesSources = new()
        {
            {PieceType.Pawn, LoadImage("Assets/Images/WhitePawn.png") },
            {PieceType.Rook, LoadImage("Assets/Images/WhiteRook.png") },
            {PieceType.Bishop, LoadImage("Assets/Images/WhiteBishop.png") },
            {PieceType.Knight, LoadImage("Assets/Images/WhiteKnight.png") },
            {PieceType.Queen, LoadImage("Assets/Images/WhiteQueen.png") },
            {PieceType.King, LoadImage("Assets/Images/WhiteKing.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> blackpiecesSources = new()
        {
            {PieceType.Pawn, LoadImage("Assets/Images/BlackPawn.png") },
            {PieceType.Rook, LoadImage("Assets/Images/BlackRook.png") },
            {PieceType.Bishop, LoadImage("Assets/Images/BlackBishop.png") },
            {PieceType.Knight, LoadImage("Assets/Images/BlackKnight.png") },
            {PieceType.Queen, LoadImage("Assets/Images/BlackQueen.png") },
            {PieceType.King, LoadImage("Assets/Images/BlackKing.png") }
        };

        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whitepiecesSources[type],
                Player.Black => blackpiecesSources[type],
                _ => null
            };
        }

        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
                return null;
            else
                return GetImage(piece.Color, piece.Type);
        }
    }
}
