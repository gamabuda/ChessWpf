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
            selectedBtn = sender as Button;
            selectedBtn.Background = Brushes.LightGreen;


        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            ChessSquare square;
            if (selectedBtn != null)
            {
                moveToButton = sender as Button;
                int selectedRow = Grid.GetRow(selectedBtn);
                int selectedCol = Grid.GetColumn(selectedBtn);
                int targetRow = Grid.GetRow(moveToButton);
                int targetCol = Grid.GetColumn(moveToButton);

                
                if ((targetRow == selectedRow - 1 || targetRow == selectedRow - 2) && targetCol == selectedCol)
                {
                    
                    Canvas.SetLeft(selectedBtn, Canvas.GetLeft(moveToButton));
                    Canvas.SetTop(selectedBtn, Canvas.GetTop(moveToButton));
                    moveToButton.Content = selectedBtn.Content;
                    selectedBtn.Content = null;

                    selectedBtn.Background = Brushes.Transparent;                  
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

