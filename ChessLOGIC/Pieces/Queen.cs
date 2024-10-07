

namespace ChessLOGIC
{
    public class Queen : Piece //inherit
    {
        public override TypePiece Type => TypePiece.Queen;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[] //normal moves for queen
       {
           //is a mix between rook  and bishop

            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthWest,
            Direction.SouthEast
       };


        //constructor 
        public Queen(Player color)
        {
            Color = color;
        }
        //copy method
        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePosInDirection(from, board, dirs).Select(to => new Normal(from, to));
        }

    }
}