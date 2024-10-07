
namespace ChessLOGIC
{
    public class Pawn : Piece //inherit
    {
        public override TypePiece Type => TypePiece.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;

        //constructor 
        public Pawn(Player color)
        {

            Color = color;
            //thats is for the movement
            if (color == Player.White)
            {
                forward = Direction.North;
            }
            else if (color == Player.Black)
            {
                forward = Direction.South;
            }
        }

        //copy method
        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInBoard(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!Board.IsInBoard(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board) //pawn can move 1 or 2 
        {
            Position oneMovePos = from + forward;

            if (CanMoveTo(oneMovePos, board))
            {
                yield return new Normal(from, oneMovePos);

                Position twoMovesPos = oneMovePos + forward;

                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new Normal(from, twoMovesPos);
                }

            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board) // pawn can move diagonal for capture
        {
            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + forward + dir;
                if (CanCaptureAt(to, board))
                {
                    yield return new Normal(from, to);
                }
            }
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }
    }

}
