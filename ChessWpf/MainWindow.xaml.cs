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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = new Button();
                    button.BorderBrush = Brushes.Transparent;
                    button.FontWeight = FontWeights.Bold;
                    button.FontSize = 16;
                    button.Width = 70;
                    button.Height = 70;

                    if ((i + j) % 2 == 0)
                        button.Background = Brushes.SaddleBrown;
                    else
                        button.Background = Brushes.Ivory;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    grid.Children.Add(button);

                    button.Click += Button_Click;
                }
            }

            char letter = 'A';

            for (int i = 1; i < 9; i++)
            {
                Label label = new Label();

                label.Width = 70;
                label.Height = 70;
                label.Foreground = Brushes.Black;
                label.Content = letter;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 30;

                Grid.SetRow(label, 0);
                Grid.SetColumn(label, i);
                grid.Children.Add(label);
                letter++;
            }

            for (int j = 1; j < 9; j++)
            {
                Label label = new Label();

                label.Width = 70;
                label.Height = 70;
                label.Foreground = Brushes.Black;
                label.Content = j;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 30;

                Grid.SetRow(label, j);
                Grid.SetColumn(label, 0);
                grid.Children.Add(label);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Content = "Pawn";
        }
    }
}
