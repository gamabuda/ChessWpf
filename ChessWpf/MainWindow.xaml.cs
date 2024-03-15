using ChessLib.Boards;
using ChessLib.Figures;
using ChessLib.Interfaces;
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
        IFigure CurrentFigure { get; set; }
        Button PrevPress { get; set; }
        Button[,] Board { get; set; } = new Button[10, 10];
        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int col = 1; col < 9; col++)
                {
                    var square = new Button
                    {
                        Background = (row + col) % 2 == 0 ? Brushes.SaddleBrown : (Brush)new BrushConverter().ConvertFrom("#D6B994"),
                        Tag = new Cell(row, col),
                        BorderBrush = Brushes.Transparent,
                        FontSize = 36,
                        Width = 70,
                        Height = 70
                    };

                    if (row == 1 || row == 2)
                        ArrangeFigures(square, "black", row, col);
                    else if (row == 7 || row == 8)
                        ArrangeFigures(square, "white", row, col);

                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);
                    grid.Children.Add(square);

                    square.Click += Button_Click;
                    Board[row, col] = square;
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

            for (int j = 1; j < 9; j++)
            {
                Label label = new Label();

                label.Width = 70;
                label.Height = 70;
                label.Foreground = Brushes.DimGray;
                label.Content = j;
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
                label2.Content = j;
                label2.HorizontalContentAlignment = HorizontalAlignment.Center;
                label2.VerticalContentAlignment = VerticalAlignment.Center;
                label2.FontSize = 30;

                Grid.SetRow(label2, j);
                Grid.SetColumn(label2, 9);
                grid.Children.Add(label2);
            }
        }

        private void ArrangeFigures(object sender, string playerColor, int i, int j)
        {
            var button = (Button)sender;
            var square = (Cell)button.Tag;

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
                {
                    Pawn pawn = new Pawn(square, "black");
                    button.Content = pawn.Figure;
                    square.Figure = pawn;
                    square.Figure.Position.Row = i;
                    square.Figure.Position.Column = j;
                    square.isFilled = true;
                    square.Figure.Color = "black";
                }

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
                {
                    Pawn pawn = new Pawn(square, "white");
                    button.Content = pawn.Figure;
                    square.Figure = pawn;
                    square.Figure.Position.Row = i;
                    square.Figure.Position.Column = j;
                    square.isFilled = true;
                    square.Figure.Color = "white";
                }
            }
            else
                throw new Exception("Incorrect player's color");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var square = (Cell)button.Tag;

            //MessageBox.Show($"You clicked on figure: {square.Figure}");

            //button.Content = null;
            if (!square.isFilled && CurrentFigure != null)
            {
                bool moved = Move(button);
                PrevPress.Content = moved ? ' ' : CurrentFigure.Figure;

                if (!moved)
                    MessageBox.Show($"Ход невозможен!");
                square.Figure = CurrentFigure;
                square.isFilled = true;
                CurrentFigure = null;

                foreach (var item in Board)
                {
                    if (item != null)
                    {
                        Cell cell = (Cell)item.Tag;
                        item.Background = (cell.Row + cell.Column) % 2 == 0 ? Brushes.SaddleBrown : (Brush)new BrushConverter().ConvertFrom("#D6B994");
                    }
                }
            }
            else if (square.isFilled)
            {
                PrevPress = button;
                CurrentFigure = square.Figure;
                CurrentFigure.Position.Row = square.Row;
                CurrentFigure.Position.Column = square.Column;

                List<(int, int)> moves = CurrentFigure.CalculateAvailableMoves();
                foreach (var move in moves)
                {
                    foreach (var item in Board)
                    {
                        if (item != null)
                        {
                            Cell cell = (Cell)item.Tag;
                            if (cell.Row == move.Item1 && cell.Column == move.Item2)
                                item.Background = Brushes.LightGreen;
                        }
                    }
                }
            }
            else if (CurrentFigure == null)
                MessageBox.Show($"Сначала выберите фигуру!");
        }

        private bool Move(Button button)
        {
            var square = (Cell)button.Tag;

            bool moved = CurrentFigure.Move(square);
            button.Content = moved ? CurrentFigure.Figure : null;
            button.FontWeight = CurrentFigure.Color == "black" ? FontWeights.Bold : FontWeights.Light;
            button.Foreground = CurrentFigure.Color == "black" ? Brushes.Black : Brushes.White;

            return moved;
        }

    }
}
