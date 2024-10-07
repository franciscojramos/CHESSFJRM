
namespace ChessLOGIC
{
    public class Rook: Piece //inherit
    {
        public override TypePiece Type => TypePiece.Rook;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[] //normal moves for rook
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West
        };


        //constructor 
        public Rook(Player color)
        {
            Color = color;
        }
        //copy method
        public override Piece Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePosInDirection(from, board, dirs).Select(to => new Normal(from, to));
        }

    }
}

