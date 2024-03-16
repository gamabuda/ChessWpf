using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameLogic;

namespace ChessWpf
{
    public partial class MainWindow : Window
    {
        private readonly Image[,] _pieceImages = new Image[8, 8];
        private readonly Rectangle[,] highlights = new Rectangle[8,8];
        private readonly Dictionary<Poses, Move> moveCache = new Dictionary<Poses, Move>();

        private StateOfGame stateOfGame;
        private Poses selectedPos = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameField();

            stateOfGame = new StateOfGame(Player.White, GameField.Initial());
            ShowGameBoard(stateOfGame.GameField);
        }

        private void InitializeGameField()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Image image = new Image();
                    _pieceImages[i, j] = image;
                    PiecesGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle();
                    highlights[i, j] = highlight;
                    CoverGrid.Children.Add(highlight);
                }
            }
        }

        private void ShowGameBoard(GameField gameField)
        {
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Piece piece = gameField[i, j];
                    _pieceImages[i, j].Source = Images.GetImage(piece);
                }
            }
        }

        private void Board_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(Board);
            Poses pos = ToSquarePos(point);

            if (selectedPos == null)
            {
                OnFromPosesSelected(pos);
            }
            else
            {
                OnToPositionSelected(pos);
            }
        }

        private void OnFromPosesSelected(Poses pos)
        {
            IEnumerable<Move> moves = stateOfGame.LegalovesForPiece(pos);

            if (moves.Any())
            {
                selectedPos = pos;
                CacheMoves(moves);
                ShowGridCover();
            }
        }

        private void OnToPositionSelected(Poses pos)
        {
            selectedPos = pos;
            HideGridCover();

            if(moveCache.TryGetValue(pos, out var move))
            {
                HandleMove(move);
            }
        }

        private void HandleMove(Move move)
        {
            stateOfGame.MakeMove(move);
            ShowGameBoard(stateOfGame.GameField);
        }

        private Poses ToSquarePos(Point point)
        {
            double squaresize = Board.ActualWidth / 8;
            int row = (int)(point.Y / squaresize);
            int col = (int)(point.X / squaresize);
            return new Poses(row, col);
        }

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();

            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
            }
        }

        private void ShowGridCover()
        {
            Color color = Color.FromArgb(150, 125, 255, 125);

            foreach(Poses to in moveCache.Keys)
            {
                highlights[to.Row, to.Col].Fill = new SolidColorBrush(color);
            }
        }

        private void HideGridCover()
        {
            foreach (Poses to in moveCache.Keys)
            {
                highlights[to.Row, to.Col].Fill = Brushes.Transparent;
            }
        }
    }
}