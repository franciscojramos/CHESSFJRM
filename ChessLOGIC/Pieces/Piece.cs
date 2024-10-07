
namespace ChessLOGIC
{
    public abstract class Piece
    {
        public abstract TypePiece Type { get; }
        public abstract Player Color { get; }


        public bool HasMoved { get; set; } = false;

        public abstract Piece Copy();
        //for movement
        public abstract IEnumerable<Move> GetMoves(Position from,Board board); // all moves can make

        //all position allowed (reachable) , for every piece thats the reason we made here inside Piece.
        protected IEnumerable<Position> MovePosInDirection(Position from, Board board, Direction dir) {

            for (Position pos = from + dir; Board.IsInBoard(pos); pos += dir)
            {
                if (board.IsEmpty(pos))// if the position is empty you can move 
                {
                    yield return pos;
                    continue; 
                }
            
                Piece piece = board[pos];

                if (piece.Color != Color)//if is not the same colour you can "eat" (is reachable) the piece
                {
                    yield return pos;
                }
                yield break; // we dont need to check more 
            }
        }
        
        protected IEnumerable<Position> MovePosInDirection(Position from , Board board , Direction[] dirs)
        {
            return dirs.SelectMany(dir => MovePosInDirection(from, board, dir));
        }

    }
}
