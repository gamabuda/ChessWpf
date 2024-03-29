
namespace ChessLibrary
{
    public class Result
    {
        public Player Winner { get;}
        public EndReason Reason { get;}
        public Result(Player player, EndReason reason)
        {
            Winner = player;
            Reason = reason;
        }
        public static Result Win(Player winner) 
        { 
            return new Result(winner, EndReason.CheckMate);
        }
        public static Result Draw(EndReason reason)
        { 
            return new Result(Player.None, reason);
        }
    }
}
