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
        public MainWindow()
        {
            InitializeComponent();
            FieldCreate();
        }

        private void FieldCreate()
        {
            for (int i = 0; i < 8; i++)
            {
                RowDefinition row = new RowDefinition();
                ColumnDefinition column = new ColumnDefinition();

                Field.RowDefinitions.Add(row);
                Field.ColumnDefinitions.Add(column);

                for (int j = 0; j < 8; j++)
                {
                    Button btn = new Button();

                    if (i % 2 != j % 2) btn.Background = Brushes.Black;
                    else btn.Background = Brushes.White;

                    btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                    btn.VerticalContentAlignment = VerticalAlignment.Center;
                    btn.Foreground = Brushes.Red;
                   
                    Grid.SetRow(btn, j);
                    Grid.SetColumn(btn, i);

                    btn.Click += ButtonClick;
                    Field.Children.Add(btn);
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (Convert.ToString(btn.Content) != "Pawn") btn.Content = "Pawn";
            else btn.Content = "";
        }
    }
}
