
namespace ChessLOGIC
{
    public class Knight : Piece //inherit
    {
        public override TypePiece Type => TypePiece.Knight;
        public override Player Color { get; }

        //constructor 
        public Knight(Player color)
        {
            Color = color;
        }
        //copy method
        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        // kNIGHT IS MORE DIFICULT BECAUSE KNIGTH CAN JUMP 
        //this are the 8 moves that knight has
        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            foreach (Direction vDir in new Direction[] { Direction.North, Direction.South })
            {
                foreach (Direction hDir in new Direction[] { Direction.West, Direction.East })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }
        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos => Board.IsInBoard(pos) //JUST THE LEGAL ONES
                && (board.IsEmpty(pos) || board[pos].Color != Color)); // empty or contain an oponent piece
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board) // JUST A GET MOVESs
        {
            return MovePositions(from, board).Select(to => new Normal(from, to));
        }

    }
}