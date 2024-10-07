
namespace ChessLOGIC
{
    public class King : Piece //inherit
    {
        public override TypePiece Type => TypePiece.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]//normal moves for king
        {
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
        public King(Player color)
        {
            Color = color;
        }
        //copy method
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;

                if (!Board.IsInBoard(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board) // JUST A GET MOVESs
        {
            foreach(Position to in MovePositions(from, board))
            {
                yield return new Normal(from, to);
            }
        }

    }
}
