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
        private int fieldSizing = 8;
        List<Button> buttons = new List<Button>();

        Button SelectedPlace;
        public MainWindow()
        {
            InitializeComponent();

            FieldCreate();
        }

        private void FieldCreate()
        {
            Pawn pawn = new Pawn(ChessFigure.Side.White, new int[] { 6, 4 });
            for (int row = 0; row < fieldSizing; row++)
            {
                for (int column = 0; column < fieldSizing; column++)
                {
                    var placement = new Button
                    {
                        Background = (row + column) % 2 == 0 ? lightSquareBrush : darkSquareBrush,
                        Tag = new ChessSquare(row, column)
                    };

                    placement.Click += PlaceClick;
                    
                    Grid.SetRow(placement, row);
                    Grid.SetColumn(placement, column);

                    if (row == 6 && column == 4)
                    {
                        ChessSquare place = placement.Tag as ChessSquare;
                        place.ChessFigure = pawn;
                        placement.Content = pawn;
                    }

                    Field.Children.Add(placement);
                    buttons.Add(placement);
                }
            }
        }

        private void PlaceClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var placement = (ChessSquare)button.Tag;

            var selectedPlace = SelectedPlace?.Tag as ChessSquare;

            var figureMove = new int[] { placement.Row, placement.Column };

            if (SelectedPlace == null)
            {
                SelectedPlace = button;
                return;
            }

            if (selectedPlace.ChessFigure.Move(figureMove))
            {
                selectedPlace.ChessFigure.Position = figureMove;
                placement.ChessFigure = selectedPlace.ChessFigure;
                button.Content = placement.ChessFigure;

                selectedPlace.ChessFigure = null;
                SelectedPlace.Content = null;

                SelectedPlace = null;
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