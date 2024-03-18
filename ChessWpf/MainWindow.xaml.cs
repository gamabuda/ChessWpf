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
        Pawn[,] amount_of_pawns = new Pawn[boardSize, boardSize];
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
                        Content = row == 6 ? "Pawn" : String.Empty
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
            if (selectedBtn != null)
            {
                
            }
        }
        Pawn selectedPawn;
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;
            if (selectedBtn != null)
            {
                moveToButton = sender as Button;
                

                
                if (selectedPawn.Move(square.Column, square.Row))
                {

                    moveToButton.Content = selectedBtn.Content;
                    selectedBtn.Content = null;

                    
                    selectedBtn = null;
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