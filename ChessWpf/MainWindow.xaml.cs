using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ChessWpf.Classes;


namespace ChessWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Tile[,] tiles { get; set; }
        IPiece activePiece;
        public MainWindow()
        {
            tiles = new Tile[8, 8];
            InitializeComponent();
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Click += ButtonClick;

                    button.Background = i % 2 == j % 2 ? Brushes.White : Brushes.Black;
                    button.Foreground = i % 2 == j % 2 ? Brushes.Black : Brushes.White;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    Desk.Children.Add(button);
                    tiles[i, j] = new Tile(button, i, j);
                }
            }
            tiles[7, 0].Piece = new Pawn(7, 0);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;

            int row = Grid.GetRow(btn);
            int column = Grid.GetColumn(btn);

            switch(btn.Content)
            {
                case "P":
                    activePiece = tiles[row, column].Piece;
                    break;
                default:
                    activePiece?.Move(row, column, tiles);
                    activePiece = null;
                    break;
            }

            Update();
        }

        private void Update()
        {
            foreach(var tile in tiles)
            {
                tile.Button.Content = tile.Piece is null ? "" : tile.Piece.Display;
            }
        }
    }
}
