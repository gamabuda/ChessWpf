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
        private ChessPiece selectedChessPiece;
        public MainWindow()
        {
            InitializeComponent();
            InitializeChessboard();
        }

        private void InitializeChessboard()
        {
            for (int i = 0; i < 8; i++)
            {
                AddChessPiece(new Pawn(i, 1), i, 1);
                AddChessPiece(new Pawn(i, 6), i, 6);
            }
        }

        private void AddChessPiece(ChessPiece chessPiece, int column, int row)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = GetPictureByChessPiece(chessPiece),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(textBlock, chessPiece.x);
            Grid.SetRow(textBlock, chessPiece.y);
            textBlock.MouseLeftButtonDown += ChessPiece_Click;
            ChessGrid.Children.Add(textBlock);
        }

        private string GetPictureByChessPiece(ChessPiece chessPiece)
        {
            switch (chessPiece)
            {
                case Pawn _:
                    return "♙";
                case King _:
                    return "♔";
                case Ferz _:
                    return "♕";
                case Ladiya _:
                    return "♖";
                case Slon _:
                    return "♗";
                case Kon _:
                    return "♘";
                default:
                    return "";
            }
        }

        private void ChessPiece_Click(object sender, MouseButtonEventArgs e)
        {
            var textBlock = sender as TextBlock;
            int column = Grid.GetColumn(textBlock);
            int row = Grid.GetRow(textBlock);
            selectedChessPiece = GetChessPieceAtPosition(column, row);

            if (selectedChessPiece != null)
            {
                Console.WriteLine($"Selected ChessPiece at ({column}, {row})");
            }
        }

        private ChessPiece GetChessPieceAtPosition(int column, int row)
        {
            foreach (var chessPiece in ChessGrid.Children)
            {
                if (chessPiece is TextBlock textBlock && Grid.GetColumn(textBlock) == column && Grid.GetRow(textBlock) == row)
                {
                    return GetChessPieceByPicture(textBlock.Text, column, row);
                }
            }
            return null;
        }

        private ChessPiece GetChessPieceByPicture(string unicode, int x, int y)
        {
            switch (unicode)
            {
                case "♙":
                    return new Pawn(x, y);
                default:
                    return null;
            }
        }

        private void UpdChessPiecePosition(ChessPiece chessPiece, int column, int row)
        {
            ChessGrid.Children.Remove(GetTextBlockAtPosition(chessPiece.x, chessPiece.y));
            AddChessPiece(chessPiece, column, row);
        }

        private TextBlock GetTextBlockAtPosition(int x, int y)
        {
            foreach (var chessPiece in ChessGrid.Children)
            {
                if (chessPiece is TextBlock textBlock && Grid.GetColumn(textBlock) == x && Grid.GetRow(textBlock) == y)
                {
                    return textBlock;
                }
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            if (selectedChessPiece != null)
            {
                if (selectedChessPiece.Move(column, row))
                {
                    UpdChessPiecePosition(selectedChessPiece, column, row);
                    selectedChessPiece = null;
                }
                else
                {
                    MessageBox.Show("Invalid move for the selected piece!");
                }
            }
            else
            {
                MessageBox.Show("Select a piece by clicking on it before making a move.");
            }
        }
    }
}
