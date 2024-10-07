
namespace ChessLOGIC
{
    public abstract class Move
    {
        public abstract Moves Type { get; }
        public abstract  Position FromPos { get; }
        public abstract Position ToPos { get; }

        public abstract void Execute(Board board); //execute the board

    }
}
