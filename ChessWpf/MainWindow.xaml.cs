using System;
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
                        Background = (row + col) % 2 == 0 ? lightSquareBrush : darkSquareBrush,
                        Tag = new ChessSquare(row, col),
                        Content = GetInitialPiece(row, col)
                    };

                    square.Click += Move_Click;
                    square.Click += Square_Click;

                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);

                    chessBoard.Children.Add(square);
                }
            }
        }

        private string GetInitialPiece(int row, int col)
        {
            if (row == 6)
                return "♟";
            else if (row == 1)
                return "♙";
            else if (row == 0)
            {
                if (col == 0 || col == 7)
                    return "♖";
                else if (col == 1 || col == 6)
                    return "♘";
                else if (col == 2 || col == 5)
                    return "♗";
                else if (col == 3)
                    return "♕";
                else if (col == 4)
                    return "♔";
            }
            else if (row == 7)
            {
                if (col == 0 || col == 7)
                    return "♜";
                else if (col == 1 || col == 6)
                    return "♞";
                else if (col == 2 || col == 5)
                    return "♝";
                else if (col == 3)
                    return "♛";
                else if (col == 4)
                    return "♚";
            }
            return String.Empty;
        }
        Button? selectedBtn;
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;

            MessageBox.Show($"You clicked on square {button.Content}: {square.Row}, {square.Column}");

            if (button.Content != null)
                selectedBtn = button;
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;

            if (selectedBtn == null)
            {
                if (string.IsNullOrEmpty(button.Content as string))
                    return;
                if (button.Content.ToString() != "♙" && button.Content.ToString() != "♟")
                    return;

                selectedBtn = button;
                return;
            }

            if (button == selectedBtn)
                return;

            var selectedSquare = (ChessSquare)selectedBtn.Tag;

            if ((selectedBtn.Content.ToString() == "♙" && square.Column == selectedSquare.Column &&
                (square.Row == selectedSquare.Row + 1 || (selectedSquare.Row == 1 && square.Row == selectedSquare.Row + 2))) ||
                (selectedBtn.Content.ToString() == "♟" && square.Column == selectedSquare.Column &&
                (square.Row == selectedSquare.Row - 1 || (selectedSquare.Row == 6 && square.Row == selectedSquare.Row - 2))))
            {
                button.Content = selectedBtn.Content;
                selectedBtn.Content = String.Empty;
            }

            selectedBtn = null;
        }
    }
}
public class ChessSquare
{
    public int Row { get; }
    public int Column { get; }

    public ChessSquare(int row, int column)
    {
        Row = row;
        Column = column;
    }
}