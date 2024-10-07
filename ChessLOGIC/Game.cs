
namespace ChessLOGIC
{
    public class Game
    {
        public Board Board { get; }

        public Player ActualPlayer { get; private set; }


        //Constructor 
        public Game(Player player, Board board)
        {
            ActualPlayer = player;
            Board = board;

        }
        public IEnumerable<Move> LegalMovesForPiece(Position pos) // just for know if the movement is legal
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != ActualPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            return piece.GetMoves(pos, Board);
            
        }
        public void MokeMove(Move move)
        {
            move.Execute(Board);
            ActualPlayer = ActualPlayer.Opponent();
        }

    }
}

