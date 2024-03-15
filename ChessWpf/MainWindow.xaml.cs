using System.Windows;
using System.Windows.Controls;
using GameLogic;

namespace ChessWpf
{
    public partial class MainWindow : Window
    {
        private readonly Image[,] _pieceImages = new Image[8, 8];
        private StateOfGame stateOfGame;
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
    }
}