using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessCore;


namespace ChessWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush lightSquareBrush = new SolidColorBrush(Colors.Beige);
        private readonly SolidColorBrush darkSquareBrush = new SolidColorBrush(Colors.SaddleBrown);
        private const int boardSize = 8;
        private Pawn[,] chessboard_list = new Pawn[boardSize, boardSize];
        public MainWindow()
        {
            InitializeComponent();
            InitializePawns();
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
                        Background = (row + col) % 2 == 0 ? lightSquareBrush : darkSquareBrush,
                        Tag = new ChessSquare(row, col),
                        Content = (chessboard_list[row, col] != null) ? "Pawn" : String.Empty
                    };

                    if (chessboard_list[row, col] != null)
                    {
                        square.Content = "Pawn";
                    }
                    square.Click += Square_Click;

                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);

                    chessBoard.Children.Add(square);
                }
            }
        }
        Pawn selectedpawn;
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;

            if (chessboard_list[square.Row, square.Column] != null)
            {
                selectedpawn = chessboard_list[square.Row, square.Column];
                button.Content = "";
                return;
            }

            if (selectedpawn != null)
            {
                if (selectedpawn.CanMove(square.Row, square.Column))
                {
                    chessboard_list[selectedpawn.X, selectedpawn.Y] = null;
                    selectedpawn.Move(square.Row, square.Column);
                    chessboard_list[selectedpawn.X, selectedpawn.Y] = selectedpawn;

                    foreach (Button b in chessBoard.Children)
                    {
                        var s = (ChessSquare)b.Tag;
                        if (s.Column == selectedpawn.X && s.Row == selectedpawn.Y)
                        {
                            b.Content = "Pawn";
                        }
                        else if (s.Column == square.Column && s.Row == square.Row)
                        {
                            b.Content = "";
                        }
                    }

                    foreach (Button b in chessBoard.Children)
                    {
                        var s = (ChessSquare)b.Tag;
                        if (s.Column == selectedpawn.X && s.Row == selectedpawn.Y)
                        {
                            b.Tag = new ChessSquare(selectedpawn.X, selectedpawn.Y);
                        }
                    }

                    selectedpawn = null;
                }
                else
                    MessageBox.Show("Ход невозможен!");
            }
        }
        private void InitializePawns()
        {
            for (int col = 0; col < boardSize; col++)
            {
                chessboard_list[1, col] = new Pawn(1, col, ChessColor.Black);
            }

            for (int col = 0; col < boardSize; col++)
            {
                chessboard_list[6, col] = new Pawn(6, col, ChessColor.White);
            }
        }
    }
}


