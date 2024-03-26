
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLibrary;

namespace Chess
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
        {
            {PieceType.Pawm, LoadImage("Assets/PawnW.png") },
            {PieceType.Rook, LoadImage("Assets/RookW.png") },
            {PieceType.Knight, LoadImage("Assets/KnightW.png") },
            {PieceType.Bishop, LoadImage("Assets/BishopW.png") },
            {PieceType.King, LoadImage("Assets/KingW.png") },
            {PieceType.Queen, LoadImage("Assets/QueenW.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> blackSoutces = new()
        {
            {PieceType.Pawm, LoadImage("Assets/PawnB.png") },
            {PieceType.Rook, LoadImage("Assets/RookB.png") },
            {PieceType.Knight, LoadImage("Assets/KnightB.png") },
            {PieceType.Bishop, LoadImage("Assets/BishopB.png") },
            {PieceType.King, LoadImage("Assets/KingB.png") },
            {PieceType.Queen, LoadImage("Assets/QueenB.png") }
        };

        private static ImageSource LoadImage(string filepath)
        {
            return new BitmapImage(new Uri(filepath, UriKind.Relative));
        }

        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSoutces[type]
            }; 
        }

        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
                return null;
            return GetImage(piece.Color, piece.Type);
        }
    }
}
