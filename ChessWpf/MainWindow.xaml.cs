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
using ChessLib;

namespace ChessWpf
{
    public partial class MainWindow : Window
    {
        private Dictionary<int, Pawn> pawns = new Dictionary<int, Pawn>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    Pawn pawn = new Pawn(i, true);
                    button.Width = 85;
                    button.Height = 95;

                    if ((i + j) % 2 == 0)
                    {
                        button.Background = Brushes.Black;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    boardGrid.Children.Add(button);
                    button.Click += Button_Click;
                    pawns[i] = pawn;

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "pawn";
                    textBlock.Foreground = Brushes.Black;
                    Grid.SetRow(textBlock, i);
                    Grid.SetColumn(textBlock, j);
                    boardGrid.Children.Add(textBlock);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Button button = new Button();
                Pawn pawn = new Pawn(i, false);
                button.Width = 85;
                button.Height = 95;

                if ((i + 1) % 2 == 0)
                {
                    button.Background = Brushes.Black;
                }
                else
                {
                    button.Background = Brushes.White;
                }

                Grid.SetRow(button, 1);
                Grid.SetColumn(button, i);
                boardGrid.Children.Add(button);
                button.Click += Button_Click;
                pawns[i] = pawn;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = "pawn";
                textBlock.Foreground = Brushes.Black;
                Grid.SetRow(textBlock, 1);
                Grid.SetColumn(textBlock, i);
                boardGrid.Children.Add(textBlock);
            }

            for (int i = 0; i < 8; i++)
            {
                Button button = new Button();
                Pawn pawn = new Pawn(i, true);
                button.Width = 85;
                button.Height = 95;

                if ((i + 1) % 2 == 0)
                {
                    button.Background = Brushes.Black;
                }
                else
                {
                    button.Background = Brushes.White;
                }

                Grid.SetRow(button, 6);
                Grid.SetColumn(button, i);
                boardGrid.Children.Add(button);
                button.Click += Button_Click;
                pawns[i] = pawn;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = "pawn";
                textBlock.Foreground = Brushes.Black;
                Grid.SetRow(textBlock, 6);
                Grid.SetColumn(textBlock, i);
                boardGrid.Children.Add(textBlock);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = Grid.GetRow(clickedButton);
            Pawn pawn = pawns[row];
            int newPosition = Grid.GetColumn(clickedButton);

            if (pawn.CanMove(newPosition))
            {
                pawn.position = newPosition;
                MessageBox.Show("Ход успешно выполнен!");
            }
            else
            {
                MessageBox.Show("Невозможно сделать ход!");
            }
        }

    }
}