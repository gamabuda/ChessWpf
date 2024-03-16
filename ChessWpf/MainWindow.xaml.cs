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
        private int selectedPawnRow = -1;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Width = 95;
                    button.Height = 95;

                    if ((i + j) % 2 == 0)
                    {
                        button.Background = Brushes.Pink;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    boardGrid.Children.Add(button);
                    button.Click += Button_Click;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Button button = new Button();
                Pawn pawn = new Pawn(i, false);
                button.Width = 95;
                button.Height = 95;

                if ((i + 1) % 2 == 0)
                {
                    button.Background = Brushes.Pink;
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

                Image image = new Image();
                image.Source = new BitmapImage(new Uri("C:\\Users\\Asus\\Source\\Repos\\ChessWpf\\ChessWpf\\pawn.png"));
                Grid.SetRow(image, 1);
                Grid.SetColumn(image, i);
                boardGrid.Children.Add(image);
            }

            for (int i = 0; i < 8; i++)
            {
                Button button = new Button();
                Pawn pawn = new Pawn(i, true);
                button.Width = 95;
                button.Height = 95;

                if ((i + 1) % 2 == 0)
                {
                    button.Background = Brushes.Pink;
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

                Image image = new Image();
                image.Source = new BitmapImage(new Uri("C:\\Users\\Asus\\Source\\Repos\\ChessWpf\\ChessWpf\\pawn.png"));
                Grid.SetRow(image, 6);
                Grid.SetColumn(image, i);
                boardGrid.Children.Add(image);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = Grid.GetRow(clickedButton);
            Pawn pawn = pawns[row];
            int newPosition = Grid.GetColumn(clickedButton);

            if (selectedPawnRow == row)
            {
                if (pawn.CanMove(newPosition))
                {
                    pawn.position = newPosition;
                    MessageBox.Show("Ход успешно выполнен!");
                    selectedPawnRow = -1;
                }
                else
                {
                    MessageBox.Show("Невозможно сделать ход!");
                }
            }
            else
            {
                selectedPawnRow = row;
            }
        }
    }

}