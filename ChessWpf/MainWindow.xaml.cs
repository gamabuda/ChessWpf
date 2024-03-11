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
    public partial class MainWindow : Window
    {
        private Button selectedButton;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (selectedButton == null)
            {
                selectedButton = button;
            }
            else
            {
                
                Grid.SetColumn(button, Grid.GetColumn(selectedButton));
                Grid.SetRow(button, Grid.GetRow(selectedButton));

                selectedButton.Content = null;
                selectedButton = null;
            }
        }
    }
}