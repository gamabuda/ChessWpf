namespace GameLogic
{
    public enum Player
    {
        None,
        White,
        Black
    }

    public static class PlayerTypes
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.White,
                Player.Black => Player.Black,
                _ => Player.None,
            };
        }
    } 
}
