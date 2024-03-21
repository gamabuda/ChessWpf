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
        Pawn[,] board = new Pawn[boardSize, boardSize];
        public MainWindow()
        {
            InitializeComponent();
            board[1, 0] = new Pawn(1, 0);
            board[1, 1] = new Pawn(1, 1);
            board[1, 2] = new Pawn(1, 2);
            board[1, 3] = new Pawn(1, 3);
            board[1, 4] = new Pawn(1, 4);
            board[1, 5] = new Pawn(1, 5);
            board[1, 6] = new Pawn(1, 6);
            board[1, 7] = new Pawn(1, 7);

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
                        Content = (board[row, col] != null) ? "Pawn" : String.Empty
                    };

                    if (board[row, col] != null)
                    {
                        square.Content = "Pawn";
                    }

                    square.Click += Move_Click;


                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);

                    chessBoard.Children.Add(square);

                }
            }
        }
        Pawn selectedpawn;

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;

            if (board[square.Column, square.Row] != null)
            {
                selectedpawn = board[square.Column, square.Row];
                return;
            }

            if (selectedpawn != null)
            {
                if (selectedpawn.Try2Move(square.Column, square.Row))
                {
                    var b= (Button)sender;
                    var s = (ChessSquare)button.Tag;
                    
                    
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
    public Pawn(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public bool Try2Move(int newX, int newY)
    {
        return (Math.Abs(x - newX) <= 1 && Math.Abs(y - newY) <= 1);
    }
}