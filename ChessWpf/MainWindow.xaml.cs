using ChessWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        List<Button> buttons = new List<Button>();

        Button ActiveSquare;
        public MainWindow()
        {
            InitializeComponent();

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Pawn pawn = new Pawn(ChessPiece.Color.White, new int[] { 7, 0 });
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    var square = new Button
                    {
                        Background = (row + col) % 2 == 0 ? lightSquareBrush : darkSquareBrush,
                        Tag = new ChessSquare(row, col)
                    };

                    square.Click += Square_Click;

                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);

                    if(row == 7 && col == 0)
                    {
                        ChessSquare aa = square.Tag as ChessSquare;
                        aa.ChessPiece = pawn;
                        square.Content = pawn;
                    }

                    chessBoard.Children.Add(square);
                    buttons.Add(square);
                }
            }
        }
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (ChessSquare)button.Tag;

            var activeSquare = ActiveSquare?.Tag as ChessSquare;

            var movesqr = new int[] { square.Row, square.Column };

            if (ActiveSquare is null)
            {
                ActiveSquare = button;
                return;
            }

            if(activeSquare.ChessPiece.Move(movesqr))
            {
                activeSquare.ChessPiece.Position = movesqr;
                square.ChessPiece = activeSquare.ChessPiece;
                button.Content = square.ChessPiece;

                activeSquare.ChessPiece = null;
                ActiveSquare.Content = null;

                ActiveSquare = null;
            }
        }
    }
}
public class ChessSquare
{
    public int Row { get; }
    public int Column { get; }
    public ChessPiece ChessPiece { get; set; }
    public ChessSquare(int row, int column)
    {
        Row = row;
        Column = column;
    }
}