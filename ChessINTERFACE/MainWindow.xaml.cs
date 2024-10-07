using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ChessLOGIC;


namespace ChessINTERFACE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] pieceImage = new Image[8, 8];
        private readonly Rectangle[,] availables = new Rectangle[8, 8];
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();//dictionary 
        

        private Game game;
        private Position selectedPos = null;
        public MainWindow()
        {
            InitializeComponent();
            Inicial();
            game = new Game(Player.White, Board.Initial()); //WHITE START ALWWAYS
            DrawBoard(game.Board);

        }

        private void Inicial()
        {
            for (int i = 0; i <8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Image image = new Image();
                    pieceImage[i, j] = image;
                    PieceGrid.Children.Add(image);

                    Rectangle available = new Rectangle();
                    availables[i, j] = available;
                    AvailableGrid.Children.Add(available);
                }
            }


        }

        private void DrawBoard(Board board)
        {

           for(int i = 0;i < 8;i++)
            {
                for(int j = 0;j < 8; j++)
                {
                    Piece piece = board[i,j];
                    pieceImage[i, j].Source = Images.GetImage(piece);
                }
            }
        }

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            Point point = e.GetPosition(BoardGrid);
            Position pos = ToSquarePosition(point);

            if (selectedPos == null)
            {
                OnFromPositionSelected(pos);
            }
            else
            {
                OnToPositionSelected(pos);
            }
        }
        private Position ToSquarePosition(Point point)
        {
            double squareSize = BoardGrid.ActualWidth / 8;
            int row = (int)(point.Y / squareSize);
            int col = (int)(point.X / squareSize);
            return new Position(row, col);
        }

        private void OnFromPositionSelected(Position pos)
        {
            IEnumerable<Move> moves = game.LegalMovesForPiece(pos);

            if (moves.Any())
            {
                selectedPos = pos;
                CacheMoves(moves);
                ShowAvailable();
            }
        }

        private void OnToPositionSelected(Position pos)
        {
            selectedPos = null;
            HideAvailable();

            if (moveCache.TryGetValue(pos, out Move move))
            {
                 
                  HandleMove(move);
                
            }
        }
        private void HandleMove(Move move)
        {
            game.MokeMove(move);
            DrawBoard(game.Board);
        }
        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();

            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
            }
        }

        private void ShowAvailable()
        {
            Color color = Color.FromArgb(150, 125, 255, 125);

            foreach (Position to in moveCache.Keys)
            {
                availables[to.Row, to.Column].Fill = new SolidColorBrush(color);
            }
        }

        private void HideAvailable()
        {
            foreach (Position to in moveCache.Keys)
            {
                availables[to.Row, to.Column].Fill = Brushes.Transparent;
            }
        }
    }
}