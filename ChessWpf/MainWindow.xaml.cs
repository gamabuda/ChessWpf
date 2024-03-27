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
        private const int fieldSizing = 8;

        private Pawn[,] placements = new Pawn[fieldSizing, fieldSizing];

        List<Button> buttons = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            placements[0, 0] = new Pawn(0, 0);
            FieldCreate();
        }

        private void FieldCreate()
        {
            for (int row = 0; row < fieldSizing; row++)
            {
                for (int column = 0; column < fieldSizing; column++)
                {
                    var placement = new Button
                    {
                        Background = (row + column) % 2 == 0 ? lightSquareBrush : darkSquareBrush,
                        Tag = new ChessSquare(row, column),
                        Content = (placements[row, column] != null) ? "Pawn" : String.Empty
                    };

                    placement.Click += PlaceClick;

                    Grid.SetRow(placement, row);
                    Grid.SetColumn(placement, column);

                    Field.Children.Add(placement);
                }
            }
        }

        Pawn selectedPawn;
        private void PlaceClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var square = button?.Tag as ChessSquare;

            if (square == null)
            {
                return;
            }

            if (placements[square.Column, square.Row] != null)
            {
                selectedPawn = placements[square.Column, square.Row];
                return;
            }

            if (selectedPawn != null && selectedPawn.IsValidMove(square.Column, square.Row, selectedPawn.HasMoved))
            {
                MovePawn(square);
            }
        }

        private void MovePawn(ChessSquare square)
        {
            foreach (Button chesspiece in Field.Children)
            {
                var moveSquare = chesspiece.Tag as ChessSquare;
                if (moveSquare != null && moveSquare.Column == selectedPawn.X && moveSquare.Row == selectedPawn.Y)
                {
                    chesspiece.Content = "";
                }
            }

            placements[selectedPawn.X, selectedPawn.Y] = null;
            selectedPawn.Y = square.Row;
            selectedPawn.X = square.Column;
            placements[square.Column, square.Row] = selectedPawn;

            selectedPawn.MovedMark();
            selectedPawn = null;

            foreach (Button chesspiece in Field.Children)
            {
                var moveSquare = chesspiece.Tag as ChessSquare;
                if (moveSquare != null && moveSquare.Column == square.Column && moveSquare.Row == square.Row)
                {
                    chesspiece.Content = "Pawn";
                }
            }
        }

        public class ChessSquare
        {
            public int Row { get; }
            public int Column { get; }
            public ChessFigure ChessFigure { get; set; }

            public ChessSquare(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }
    }
}