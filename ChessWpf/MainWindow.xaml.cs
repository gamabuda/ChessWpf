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
                    button.FontSize = 36;
                    button.Width = 70;
                    button.Height = 70;

                    if ((i + j) % 2 == 0)
                        button.Background = Brushes.SaddleBrown;
                    else
                        button.Background = (Brush)new BrushConverter().ConvertFrom("#D6B994");

                    if (i == 1 || i == 2)
                        ArrangeFigures(button, "black", i, j);
                    else if (i == 7 || i == 8)
                        ArrangeFigures(button, "white", i, j);

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
                label.Foreground = Brushes.DimGray;
                label.Content = letter;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 30;

                Grid.SetRow(label, 0);
                Grid.SetColumn(label, i);
                grid.Children.Add(label);

                Label label2 = new Label();

                label2.Width = 70;
                label2.Height = 70;
                label2.Foreground = Brushes.DimGray;
                label2.Content = letter;
                label2.HorizontalContentAlignment = HorizontalAlignment.Center;
                label2.VerticalContentAlignment = VerticalAlignment.Center;
                label2.FontSize = 30;

                Grid.SetRow(label2, 9);
                Grid.SetColumn(label2, i);
                grid.Children.Add(label2);

                letter++;
            }

            char digit = '8';

            for (int j = 1; j < 9; j++)
            {
                Label label = new Label();

                label.Width = 70;
                label.Height = 70;
                label.Foreground = Brushes.DimGray;
                label.Content = digit;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 30;

                Grid.SetRow(label, j);
                Grid.SetColumn(label, 0);
                grid.Children.Add(label);

                Label label2 = new Label();

                label2.Width = 70;
                label2.Height = 70;
                label2.Foreground = Brushes.DimGray;
                label2.Content = digit;
                label2.HorizontalContentAlignment = HorizontalAlignment.Center;
                label2.VerticalContentAlignment = VerticalAlignment.Center;
                label2.FontSize = 30;

                Grid.SetRow(label2, j);
                Grid.SetColumn(label2, 9);
                grid.Children.Add(label2);

                digit--;
            }
        }

        private void ArrangeFigures(object sender, string playerColor, int i, int j)
        {
            var button = sender as Button;

            if (playerColor.ToLower().Trim() == "black")
            {
                button.Foreground = Brushes.Black;
                button.FontWeight = FontWeights.ExtraBold;

                if (i == 1 && j == 1 || i == 1 && j == 8)
                    button.Content = "♖";
                else if (i == 1 && j == 2 || i == 1 && j == 7)
                    button.Content = "♘";
                else if (i == 1 && j == 3 || i == 1 && j == 6)
                    button.Content = "♗";
                else if (i == 1 && j == 4)
                    button.Content = "♕";
                else if (i == 1 && j == 5)
                    button.Content = "♔";
                else if (i == 2)
                    button.Content = "♙";
            }
            else if (playerColor.ToLower().Trim() == "white")
            {
                button.Foreground = Brushes.White;
                button.FontWeight = FontWeights.Light;

                if (i == 8 && j == 1 || i == 8 && j == 8)
                    button.Content = "♖";
                else if (i == 8 && j == 2 || i == 8 && j == 7)
                    button.Content = "♘";
                else if (i == 8 && j == 3 || i == 8 && j == 6)
                    button.Content = "♗";
                else if (i == 8 && j == 4)
                    button.Content = "♕";
                else if (i == 8 && j == 5)
                    button.Content = "♔";
                else if (i == 7)
                    button.Content = "♙";
            }
            else
                throw new Exception("Incorrect player's color");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            button.Content = button.Content == null ? "♙" : null;
            button.FontWeight = FontWeights.Bold;

        }
    }
}
