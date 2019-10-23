using System;
using SvoyaIgra;
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

namespace Svoya_Igra_Design
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

        Button[,] btns = new Button[6, 6];
        TextBox[] textBoxes = new TextBox[6];

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            questionsGrid.Children.Clear();
            questionsGrid.ColumnDefinitions.Clear();
            questionsGrid.RowDefinitions.Clear();

            ColumnDefinition cd3 = new ColumnDefinition();
            cd3.Width = new GridLength(130);
            questionsGrid.ColumnDefinitions.Add(cd3);

            for (int i = 0; i < questionThemeSlider.Value; i++)
            {
                RowDefinition cd2 = new RowDefinition();
                cd2.Height = new GridLength(45);
                questionsGrid.RowDefinitions.Add(cd2);

                textBoxes[i] = new TextBox { Text = "Название темы ;)" };
                questionsGrid.Children.Add(textBoxes[i]);
                Grid.SetRow(textBoxes[i], i);
                Grid.SetColumn(textBoxes[i], 0);

                for (int j = 1; j <= questionCostSlider.Value; j++)
                {
                    ColumnDefinition cd1 = new ColumnDefinition();
                    cd1.Width = new GridLength(100);
                    questionsGrid.ColumnDefinitions.Add(cd1);
                    btns[i, j-1] = new Button { Content = j * 100 };
                    questionsGrid.Children.Add(btns[i, j-1]);
                    Grid.SetRow(btns[i, j-1], i);
                    Grid.SetColumn(btns[i, j-1], j);
                    btns[i, j-1].Click += Button1_Click;
                }
            }
        }

        void Button1_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(sender as Button) - 1;
            int row = Grid.GetRow(sender as Button);
            MessageBox.Show(column + " " + row);
        }
    }
}
