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
        List<Label> Signatures = new List<Label>();
        List<Label> AdditionalSignatures = new List<Label>();
        public MainWindow()
        {
            InitializeComponent();
            DrawField();
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
    }
}
