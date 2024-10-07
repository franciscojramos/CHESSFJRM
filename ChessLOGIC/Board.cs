
namespace ChessLOGIC
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }

        }
        public Piece this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }
        private void StartingPieces()
        {
            //White Pieces
            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);


            //Black Pieces
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            // to add the pawns we are going to do a loop to avoid code repetititon.

            for (int a = 0; a < 8; a++)
             {
                this[1,a] = new Pawn(Player.Black);
                this[6, a] = new Pawn(Player.White);            
             }


        }
        // Constructor for initial board with the pieces

        public static Board Initial()
        {
            Board board = new Board();
            // we call the method for starting pieces 
            board.StartingPieces();
            return board;
        }

        public static bool IsInBoard(Position pos)
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        // method for know if is empty TRUE if we dont have anything in this position

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }

    }
}
