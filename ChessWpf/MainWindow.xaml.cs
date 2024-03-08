using ChessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
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
        List<Label> Signatures = new List<Label>();
        List<Label> AdditionalSignatures = new List<Label>();
        Game game;
        Dictionary<Image, Cell> CellBindings; 

        public MainWindow()
        {
            game = new Game();
            game.StartGame();
            CellBindings = new Dictionary<Image, Cell>();
            InitializeComponent();
            DrawField();
            UpdateCells();
        }

        private void DrawField()
        {
            for (int i = 0; i < 8; i++)
            {
                RowDefinition row = new RowDefinition();
                ColumnDefinition col = new ColumnDefinition();

                Field.RowDefinitions.Add(row);
                Field.ColumnDefinitions.Add(col);

                for (int j = 0; j < 8; j++)
                {
                    Rectangle rect = new Rectangle();
                    Image icon = new Image();
                    
                    rect.Fill = i % 2 != j % 2 ? Brushes.Black : Brushes.White;
                    rect.Stroke = Brushes.Black;

                    Grid.SetRow(rect, j);
                    Grid.SetColumn(rect, i);
                    Field.Children.Add(rect);

                    Grid.SetRow(icon, j);
                    Grid.SetColumn(icon, i);
                    Field.Children.Add(icon);
                    icon.MouseEnter += HandCursor;
                    icon.MouseLeave += DefaultCursor;
                    icon.MouseLeftButtonDown += Click;
                    CellBindings.Add(icon, game.board[j, i]);
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            char letter = 'a';
            char digit = '1';
            for(int i = 0;i < 8;i++)
            {
                Label letterLabel = new()
                {
                    Content = letter,
                    IsHitTestVisible = false,
                    IsEnabled = false,
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                Label digitLabel = new()
                {
                    Content = digit,
                    IsHitTestVisible = false,
                    IsEnabled = false,
                    VerticalAlignment = VerticalAlignment.Bottom
                };

                Field.Children.Add(digitLabel);
                Field.Children.Add(letterLabel);
                Grid.SetRow(digitLabel, i);
                Grid.SetColumn(letterLabel, i);
                Signatures.Add(letterLabel);
                Signatures.Add(digitLabel);
                letter++;
                digit++;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach(Label lbl in Signatures)
            {
                lbl.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            char letter = 'a';
            char digit = '1';

            for (int i = 0; i < 8; i++)
            {
                letter = 'a';
                for (int j = 0; j < 8; j++)
                {
                    Label label = new()
                    {
                        Content = $"{letter}{digit}",
                        IsHitTestVisible = false,
                        IsEnabled = false
                    };

                    Field.Children.Add(label);
                    Grid.SetColumn(label, j);
                    Grid.SetRow(label, i);

                    letter++;
                    AdditionalSignatures.Add(label);
                }
                digit++;
            }
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            foreach(Label lbl in AdditionalSignatures)
            {
                lbl.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateCells()
        {
            foreach(var keyValuePair in CellBindings)
            {
                string key = keyValuePair.Value.CurrentState.ToString();
                if (key != "Empty" || key == "CanMoveCell" && game.CurrentActiveCell == null)
                    keyValuePair.Key.Source = new BitmapImage(new Uri($"\\{key}.png", UriKind.Relative));
                else
                    keyValuePair.Key.Source = null;
            }
        }

        private void HandCursor(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void DefaultCursor(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Image presenter = e.Source as Image;
            Cell cell = CellBindings[presenter];

            if (cell.Piece != null)
            {
                IPiece piece = CellBindings[presenter].Piece;
                piece.CalculatePossibleMoves(game.board);
                game.CurrentActivePiece = piece;
                game.CurrentActiveCell = cell;
                foreach (var move in piece.AvailableMoves)
                {
                    game.board[move.Item1, move.Item2].CurrentState = State.CanMoveCell;
                }
            }
            else
            {
                cell.PutPiece(game.CurrentActivePiece);
                cell.CurrentState = game.CurrentActivePiece.State;
                game.DoInactive();
            }
            UpdateCells();
        }
    }
}
