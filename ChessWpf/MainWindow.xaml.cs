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
        private int fieldSizing = 8;

        public MainWindow()
        {
            InitializeComponent();
            FieldCreate();
        }

        private void FieldCreate()
        {
            for (int row = 0; row < fieldSizing; row++)
            {
                for (int column = 0; column < fieldSizing; column++)
                {
                    var placement = new Button();
                    if (row % 2 != column % 2)
                    {
                        placement.Background = Brushes.Beige;
                        Tag = new ChessSquare(row, column);
                    }
                    else placement.Background = Brushes.SaddleBrown;

                    Grid.SetRow(placement, row);
                    Grid.SetColumn(placement, column);

                    placement.Click += ButtonClick;

                    Field.Children.Add(placement);
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var placement = (ChessSquare)button.Tag;

            if (Convert.ToString(button.Content) != "Pawn") button.Content = "Pawn";
            else button.Content = "";
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
    }
}
