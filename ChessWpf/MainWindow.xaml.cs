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
        private readonly SolidColorBrush lightSquareBrush = new SolidColorBrush(Colors.Beige);
        private readonly SolidColorBrush darkSquareBrush = new SolidColorBrush(Colors.SaddleBrown);
        private const int boardSize = 8;
        private Button[,] squares = new Button[boardSize, boardSize]; // Для доступа к квадратам по индексам
        private ChessSquare selectedSquare = null; // Для хранения выбранной пешки

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
                        Content = row == 6 ? "P" : string.Empty, 
                        Tag = new ChessSquare(row, col)
                    };

                    square.Click += Square_Click;
                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);
                    chessBoard.Children.Add(square);
                    squares[row, col] = square; 
                }
            }
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;

            // Если пешка уже выбрана и клик произошел по другому квадрату
            if (selectedSquare != null && (selectedSquare.Row != square.Row || selectedSquare.Column != square.Column))
            {
                // Перемещаем пешку, если ход допустим
                MovePawn(square);
                selectedSquare = null; // Сбрасываем выбранную пешку
            }
            else if (button.Content.ToString() == "P") // Если кликнули на пешку, выбираем её
            {
                selectedSquare = square;
            }
        }

        private void MovePawn(ChessSquare toSquare)
        {
            // Проверка допустимости хода
            if (Math.Abs(toSquare.Row - selectedSquare.Row) == 1 && toSquare.Column == selectedSquare.Column)
            {
                squares[selectedSquare.Row, selectedSquare.Column].Content = string.Empty; // Предыдущая пешка убирается
                squares[toSquare.Row, toSquare.Column].Content = "P"; // Пешка ставится на новое место
            }
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