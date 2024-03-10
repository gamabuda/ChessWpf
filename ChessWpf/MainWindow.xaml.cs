using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public MainWindow()
        {
            InitializeComponent();


        }
        private Button selectedPawnButton;
        private Pawn selectedPawn;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            // Проверка наличия пешки на нажатой кнопке (вместо btn.Content.ToString() == "Pawn")
            if (btn.Content != null && btn.Content.ToString() == "Pawn")
            {
                if (selectedPawnButton != null)
                {
                    // Проверка правильности хода пешки
                    if (selectedPawn.CheckPawnMove(selectedPawnButton, btn))
                    {
                        btn.Content = "Pawn";
                        selectedPawnButton.Content = "";
                        selectedPawnButton = null;
                        selectedPawn = null;
                    }
                }
                else
                {
                    selectedPawnButton = btn;
                    selectedPawn = new Pawn(Grid.GetRow(btn), Grid.GetColumn(btn));
                }
            }
            else if (selectedPawnButton != null)
            {
                // Перемещение пешки на другую клетку
                if (selectedPawn.CheckPawnMove(selectedPawnButton, btn))
                {
                    btn.Content = "Pawn";
                    selectedPawnButton.Content = "";
                    selectedPawnButton = null;
                    selectedPawn = null;
                }
            }
        }
        public class Figure
        {
            public int x;
            public int y;

            public Figure(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Pawn : Figure
        {
            public Pawn(int x, int y) : base(x, y) { }

            public bool CheckPawnMove(Button fromButton, Button toButton)
            {
                int newX = Grid.GetRow(toButton);
                int newY = Grid.GetColumn(toButton);

                if (newY != this.y)
                {
                    return false; // пешка не может двигаться по горизонтали
                }

                if (newX == this.x + 1 || (this.x == 1 && newX == 3))
                {
                    return true; // пешка может двигаться на одну позицию вперед или на две с начальной позиции
                }

                return false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}