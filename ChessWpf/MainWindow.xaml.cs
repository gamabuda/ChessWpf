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
                        Tag = new Pawn(row, col),
                        Content = String.Empty
                    };

                    if (row < 2 || row > 5)
                    {
                        square.Content = "Pawn";
                        board[row, col] = new Pawn(row, col);
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

            if (board[square.x, square.y] != null)
            {
                selectedPawn = board[square.x, square.y];
            }
            else if (selectedPawn != null)
            {
                if (selectedPawn.CanMove(square.x, square.y) || selectedPawn.CanCapture(square.x, square.y))
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

        private void UpdateBoard(Pawn pawn, Pawn targetSquare)
        {
            foreach (Button b in boardGrid.Children)
            {
                var s = (Pawn)b.Tag;
                if (s.x == pawn.x && s.y == pawn.y)
                {
                    b.Content = String.Empty;
                }
            }

            board[pawn.x, pawn.y] = null;
            pawn.y = targetSquare.y;
            pawn.x = targetSquare.x;
            board[targetSquare.x, targetSquare.y] = pawn;

            foreach (Button b in boardGrid.Children)
            {
                var s = (Pawn)b.Tag;
                if (s.x == targetSquare.x && s.y == targetSquare.y)
                {
                    b.Content = "Pawn";
                }
            }
        }
    }
 }
