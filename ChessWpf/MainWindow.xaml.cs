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

        private Image selectedPawn;
        private Rectangle originalRectangle;
        private bool isFirstMove = true;

        public MainWindow()
        {
            InitializeComponent();
            CreateChessboard();
            AddPawn();
        }

        private void CreateChessboard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var square = new Rectangle();
                    square.Width = 50;
                    square.Height = 50;
                    square.Fill = (i + j) % 2 == 0 ? Brushes.Beige : Brushes.SaddleBrown;
                    square.MouseLeftButtonDown += Square_MouseLeftButtonDown;

                    Grid.SetRow(square, i);
                    Grid.SetColumn(square, j);
                    chessGrid.Children.Add(square);
                }
            }
        }

        private void AddPawn()
        {
            var pawnImage = new Image();
            pawnImage.Source = new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ChessWpf\\ChessWpf\\pngwing.com (6).png")); // Укажите свой путь к изображению
            pawnImage.Width = 50;
            pawnImage.Height = 50;
            pawnImage.MouseLeftButtonDown += PawnImage_MouseLeftButtonDown;

            Grid.SetRow(pawnImage, 1);
            Grid.SetColumn(pawnImage, 6);
            chessGrid.Children.Add(pawnImage);
        }

        private void PawnImage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selectedPawn != null)
            {
                selectedPawn.Effect = null;
                selectedPawn = null;
            }

            selectedPawn = (Image)sender;
            originalRectangle = FindParent<Rectangle>(selectedPawn);
            if (originalRectangle != null)
            {
                originalRectangle.Fill = Brushes.LightGreen;
            }
        }

        private void Square_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var square = (Rectangle)sender;
            if (selectedPawn != null)
            {
                int selectedRow = Grid.GetRow(selectedPawn);
                int selectedColumn = Grid.GetColumn(selectedPawn);
                int targetRow = Grid.GetRow(square);
                int targetColumn = Grid.GetColumn(square);

                if ((targetRow == selectedRow + 1 && targetColumn == selectedColumn) ||
                    (isFirstMove && targetRow == selectedRow + 2 && targetColumn == selectedColumn))
                {
                    Grid.SetRow(selectedPawn, targetRow);
                    Grid.SetColumn(selectedPawn, targetColumn);

                    isFirstMove = false;

                    if (originalRectangle != null)
                    {
                        originalRectangle.Fill = (Grid.GetRow(originalRectangle) + Grid.GetColumn(originalRectangle)) % 2 == 0 ? Brushes.Beige : Brushes.Brown;
                    }
                }
                selectedPawn = null;
            }
        }

        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            if (parentObject is T parent)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }
}

