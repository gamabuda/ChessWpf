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
        private Pawn[,] chessboard_list = new Pawn[boardSize, boardSize];
        public MainWindow()
        {
            InitializeComponent();
            chessboard_list[0, 0] = new Pawn(0, 0);
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

                    if(chessboard_list[row, col] != null)
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

            if (chessboard_list[square.Column, square.Row] != null)
            {
                selectedpawn = chessboard_list[square.Column, square.Row];
                return;
            }

            if(selectedpawn != null)
            {
                if(selectedpawn.Try2Move(square.Column, square.Row))
                {
                    foreach (Button b in chessBoard.Children)
                    {
                        var s = (ChessSquare)b.Tag;
                        if (s.Column == selectedpawn.x && s.Row == selectedpawn.y)
                        {
                            b.Content = "";
                        }
                    }

                    chessboard_list[selectedpawn.x, selectedpawn.y] = null;
                    selectedpawn.y = square.Row;
                    selectedpawn.x = square.Column;
                    chessboard_list[square.Column, square.Row] = selectedpawn;

                    selectedpawn = null;
                    foreach(Button b in chessBoard.Children)
                    {
                        var s = (ChessSquare)b.Tag;
                        if(s.Column == square.Column && s.Row == square.Row)
                        {
                            b.Content = "Pawn";
                        }
                    }
                }
            }

            //MessageBox.Show($"You clicked on square {button.Content}: {square.Row}, {square.Column}");
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