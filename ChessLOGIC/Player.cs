namespace ChessLOGIC
{
    public enum Player
    {
        None,
        White,
        Black
    }

   public static class PlayerExtensions
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                _ => Player.None,

                /*// you can use this instead
                switch(player)
                     {
                    case Player.White:
                        return Player.Black;
                    case Player.Black:
                        return Player.White;
                    default:
                        return Player.None;
                */
            };
        }

    }
}
