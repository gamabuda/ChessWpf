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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Content = "Pawn";
        }
        public enum State
        {
            Empty,       // пусто
            WhiteKing,   // король
            WhiteQueen,  // ферзь
            WhiteRook,   // ладья
            WhiteKnight, // конь
            WhiteBishop, // слон
            WhitePawn,   // пешка
            BlackKing,
            BlackQueen,
            BlackRook,
            BlackKnight,
            BlackBishop,
            BlackPawn
        }

    }
}
