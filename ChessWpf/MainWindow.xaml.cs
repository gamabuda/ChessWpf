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
                        Content = row == 7 ? "Pawn" : String.Empty
                    };

                    square.Click += Move_Click;
                    square.Click += Square_Click;


                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);

                    chessBoard.Children.Add(square);
                }
            }
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
                return;

            button.Content = selectedBtn.Content;
            selectedBtn.Content = String.Empty;
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
public class Pawn
{
    public int Row { get; set; }
    public int Column { get; set; }
    public char Symbol { get; }

    public Pawn(int row, int column)
    {
        Row = row;
        Column = column;
        Symbol = '♙'; 
    }

    public bool IsValidMove(int destRow, int destColumn)
    {
        if (destRow < 0 || destRow >= 8 || destColumn < 0 || destColumn >= 8)
        {
            return false; 
        }

        if (destColumn == Column && destRow == Row + 1)
        {
            return true; 
        }

        return false; 
    }
}



