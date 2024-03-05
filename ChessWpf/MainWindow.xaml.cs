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
            for (int i = 0; i <= 8; i++)
            {
                RowDefinition row = new RowDefinition();
                ColumnDefinition col = new ColumnDefinition();

                Field.RowDefinitions.Add(row);
                Field.ColumnDefinitions.Add(col);

                for (int j = 0; j <= 8; j++)
                {
                    Button btn = new Button();
                    btn.Background = i % 2 != j % 2 ? Brushes.Black : Brushes.White;
                    btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                    btn.VerticalContentAlignment = VerticalAlignment.Top;

                    Grid.SetRow(btn, j);
                    Grid.SetColumn(btn, i);
                    Field.Children.Add(btn);
                }
            }
        }
    }
}
