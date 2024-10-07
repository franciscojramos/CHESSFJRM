

namespace ChessLOGIC
{
    public class Normal : Move
    {
        public override Moves Type => Moves.Normal;
        //properties
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        //constructor
        public Normal (Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
        }

        //execute method
        public override void Execute(Board board)
        {
            Piece piece = board[FromPos];
            board[ToPos] = piece;
            board[FromPos] = null; // REMOVE TO THE ORIGINAL POSITION
            //HAS MOVED TRUE
            piece.HasMoved = true;
        }
    }
}
