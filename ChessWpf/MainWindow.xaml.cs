using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessWpf
{

    public partial class MainWindow : Window
    {

        private const int BoardSize = 8;
        private const int TileSize = 50;

        private List<Rectangle> squares = new List<Rectangle>();
        private List<Image> pawns = new List<Image>();

        private SolidColorBrush lightBrush = new SolidColorBrush(Colors.White);
        private SolidColorBrush darkBrush = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush highlightBrush = new SolidColorBrush(Colors.LightGreen);

        private int selectedPawnIndex = -1;
        private int selectedCellIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
            DrawChessboard();
            DrawPawns();
        }

        private void DrawChessboard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Rectangle square = new Rectangle
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Fill = (i + j) % 2 == 0 ? lightBrush : darkBrush
                    };

                    Canvas.SetLeft(square, j * TileSize);
                    Canvas.SetTop(square, i * TileSize);

                    chessboardCanvas.Children.Add(square);
                    squares.Add(square);

                    int index = i * BoardSize + j;
                    square.MouseLeftButtonDown += (sender, e) => Square_Clicked(index);
                }
            }
        }

        private void DrawPawns()
        {
            string pawnImagePath = "C:\\Users\\user\\source\\repos\\ChessWpf\\ChessWpf\\pngwing.com (6).png";

            for (int i = 0; i < BoardSize; i++)
            {
                Image pawn = new Image
                {
                    Source = new BitmapImage(new Uri(pawnImagePath)),
                    Width = TileSize,
                    Height = TileSize,
                    Stretch = Stretch.Fill
                };

                Canvas.SetLeft(pawn, i * TileSize);
                Canvas.SetTop(pawn, (BoardSize - 2) * TileSize);

                chessboardCanvas.Children.Add(pawn);
                pawns.Add(pawn);

                int index = i;
                pawn.MouseLeftButtonDown += (sender, e) => Pawn_Clicked(index);
            }
        }

        private void Pawn_Clicked(int index)
        {
            if (selectedPawnIndex == -1)
            {
                selectedPawnIndex = index;
                squares[index + (BoardSize - 2) * BoardSize].Fill = highlightBrush;
            }
            else
            {
                squares[selectedPawnIndex + (BoardSize - 2) * BoardSize].Fill = (selectedPawnIndex % 2 == 0) ? lightBrush : darkBrush;

                selectedCellIndex = index + (BoardSize - 2) * BoardSize;
                MovePawn();
            }
        }

        private void Square_Clicked(int index)
        {
            if (selectedPawnIndex != -1)
            {
                squares[selectedPawnIndex + (BoardSize - 2) * BoardSize].Fill = (selectedPawnIndex % 2 == 0) ? lightBrush : darkBrush;

                selectedCellIndex = index;
                MovePawn();
            }
        }

        private void MovePawn()
        {
            int row = selectedCellIndex / BoardSize;
            int col = selectedCellIndex % BoardSize;

            Canvas.SetLeft(pawns[selectedPawnIndex], col * TileSize);
            Canvas.SetTop(pawns[selectedPawnIndex], row * TileSize);

            squares[selectedCellIndex].Fill = (row + col) % 2 == 0 ? lightBrush : darkBrush;

            selectedPawnIndex = -1;
            selectedCellIndex = -1;
        }
    }
}

