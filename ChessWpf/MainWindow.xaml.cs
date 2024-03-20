
using ChessLib;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush lightBrush = new SolidColorBrush(Colors.White);
        private readonly SolidColorBrush darkBrush = new SolidColorBrush(Colors.Pink);
        private const int boardSize = 8;
        private Pawn[,] board = new Pawn[boardSize, boardSize];

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    var square = new Button
                    {
                        Background = (row + col) % 2 == 0 ? lightBrush : darkBrush,
                        Tag = new Pawn(row, col, Colorsquare.White),
                        Content = string.Empty
                    };

                    if (row < 1)
                    {
                        square.Content = "Pawn";
                        board[row, col] = new Pawn(row, col, Colorsquare.Black);
                    }
                    if (row > 6)
                    {
                        square.Content = "Pawn";
                        board[row, col] = new Pawn(row, col, Colorsquare.White);
                    }

                    square.Click += Button_Click;

                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);

                    boardGrid.Children.Add(square);
                }
            }
        }

        Pawn selectedPawn;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (Pawn)button.Tag;

            if (board[square.X, square.Y] != null)
            {
                selectedPawn = board[square.X, square.Y];
            }
            else if (selectedPawn != null)
            {
                if (selectedPawn.CanMove(square.X, square.Y) || selectedPawn.CanCapture(square.X, square.Y))
                {
                    UpdateBoard(selectedPawn, square);
                    selectedPawn = null;
                    MessageBox.Show("Ход успешно выполнен!");
                }
                else
                {
                    MessageBox.Show("Невозможно сделать ход!");
                }
            }
        }

        private void UpdateBoard(Pawn pawn, Pawn square)
        {
            foreach (Button b in boardGrid.Children)
            {
                var s = (Pawn)b.Tag;
                if (s.X == pawn.X && s.Y == pawn.Y)
                {
                    b.Content = "";
                }
            }

            board[pawn.X, pawn.Y] = null;
            pawn.Y = square.Y;
            pawn.X = square.X;
            board[square.X, square.Y] = pawn;

            foreach (Button b in boardGrid.Children)
            {
                var s = (Pawn)b.Tag;
                if (s.X == square.X && s.Y == square.Y)
                {
                    b.Content = "Pawn";
                }
            }
        }
    }
}
