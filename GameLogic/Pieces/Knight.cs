namespace GameLogic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Bishop;
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
    }
}
