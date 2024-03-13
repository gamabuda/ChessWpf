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
        private Button[,] squares = new Button[boardSize, boardSize]; 
        private ChessSquare selectedSquare = null; 


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
                        Content = row == 6 ? "P" : string.Empty, FontSize = 40,
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

           
            if (selectedSquare != null && (selectedSquare.Row != square.Row || selectedSquare.Column != square.Column))
            {
                
                MovePawn(square);
                selectedSquare = null; 
            }
            else if (button.Content.ToString() == "P") 
            {
                selectedSquare = square;
            }
        }



        private void MovePawn(ChessSquare toSquare)
        {
            
            int rowDifference = toSquare.Row - selectedSquare.Row;
            int columnDifference = Math.Abs(toSquare.Column - selectedSquare.Column);

            
            bool isForwardMove = rowDifference < 0;
            bool isInitialMove = !selectedSquare.HasPawnMoved && rowDifference == -2 && columnDifference == 0; // Движение на 2 клетки из начальной позиции
            bool isRegularMove = rowDifference == -1 && columnDifference == 0; // Обычное движение на 1 клетку

            // ход пешки
            if ((isForwardMove && (isInitialMove || isRegularMove)) && squares[toSquare.Row, toSquare.Column].Content.ToString() == string.Empty) 
            {
                squares[selectedSquare.Row, selectedSquare.Column].Content = string.Empty; 
                squares[toSquare.Row, toSquare.Column].Content = "P";
                selectedSquare.HasPawnMoved = true; 
                toSquare.HasPawnMoved = true;
            }
        }
    }
}
    public class ChessSquare
{
    public int Row { get; }
    public int Column { get; }
    public bool HasPawnMoved { get; set; }

    public ChessSquare(int row, int column)
    {
        Row = row;
        Column = column;
        HasPawnMoved = false; 
    }
}