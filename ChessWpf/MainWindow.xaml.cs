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
        private Button moveToButton;
        Pawn[,] board = new Pawn[boardSize, boardSize];
        public MainWindow()
        {
            InitializeComponent();
            board[7, 1] = new Pawn(6, 1);
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
                        Content = (board[row, col] != null)? "Pawn" : String.Empty
                    };

                    square.Click += Move_Click;
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
            if (board[square.Row, square.Column] != null)
            {
                selectedpawn = board[square.Row, square.Column];
            }
        }
        Pawn selectedPawn;
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;
            if (selectedpawn != null)
            {            
                if (selectedPawn.Move(square.Column, square.Row))
                {
                    board[selectedpawn.x, selectedpawn.y] = null;
                    selectedpawn.y = square.Row;
                    selectedpawn.x = square.Column;
                    board[square.Column, square.Row] = selectedpawn;
                    var btn = (Button)sender;
                    var s = (ChessSquare)btn.Tag;
                    if (s.Column == square.Column&& s.Row == square.Row)
                    {
                        btn.Content = "Pawn";
                    }
                }
                else
                {
                    MessageBox.Show("Неверный ход! Пешка может ходить только на одну или две клетки вперед.");
                }
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
public class Pawn
{
    public int x;
    public int y;
    public Pawn(int newX, int newY)
    {
        this.x = newX;
        this.y = newY;
    }
    public  bool Move(int newX, int newY)
    {
        return (Math.Abs(x - newX) <= 1 && Math.Abs(y - newY) == 1);
    }
}