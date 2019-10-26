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

        Config cfg = new Config();

        Button[,] btns = new Button[6, 6];
        TextBox[] textBoxes = new TextBox[6];
        int column;
        int row;

        private void createTableButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTable();
            CreateColumn(124);

            for (int i = 0; i < questionThemeSlider.Value; i++)
            {
                CreateRow(50);
                CreateTextBoxInTable(i);

                for (int j = 1; j <= questionCostSlider.Value; j++)
                {
                    CreateColumn(101);
                    CreateButtonInTable(i, j);
                }
            }
        }

        private void ClearTable()
        {
            questionsGrid.Children.Clear();
            questionsGrid.ColumnDefinitions.Clear();
            questionsGrid.RowDefinitions.Clear();
        }

        private void CreateColumn(int width)
        {
            ColumnDefinition cd = new ColumnDefinition();
            cd.Width = new GridLength(width);
            questionsGrid.ColumnDefinitions.Add(cd);
        }

        private void CreateRow(int height)
        {
            RowDefinition rd = new RowDefinition();
            rd.Height = new GridLength(height);
            questionsGrid.RowDefinitions.Add(rd);
        }

        private void CreateTextBoxInTable(int i)
        {
            textBoxes[i] = new TextBox { Text = "Название темы ;)" };
            questionsGrid.Children.Add(textBoxes[i]);
            Grid.SetRow(textBoxes[i], i);
            Grid.SetColumn(textBoxes[i], 0);
        }

        private void CreateButtonInTable(int i, int j)
        {
            btns[i, j - 1] = new Button { Content = j * 100 };
            questionsGrid.Children.Add(btns[i, j - 1]);
            Grid.SetRow(btns[i, j - 1], i);
            Grid.SetColumn(btns[i, j - 1], j);
            btns[i, j - 1].Click += cell_Click;
        }

        void cell_Click(object sender, RoutedEventArgs e)
        {
            column = Grid.GetColumn(sender as Button) - 1;
            row = Grid.GetRow(sender as Button);
            if (cfg.Questions[row][column] == null)
                questionContentTextBox.Text = string.Format("Введите вопрос для ячейки ;) (строка: {0}, столбец: {1})", row, column);
            else
                questionContentTextBox.Text = string.Format("{0} (строка: {1}, столбец: {2})", cfg.Questions[row][column], row, column);
            questionContentTextBox.Focusable = true;
        }

        private void questionContentTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            questionContentTextBox.Clear();
        }

        private void questionSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!cfg.Questions.ContainsKey(row))
                cfg.Questions.Add(row,new string[6]);
            cfg.Questions[row][column] = questionContentTextBox.Text;
            MessageBox.Show(cfg.Questions[row][column]);
        }

        private void createGameButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                cfg.Themes[i] = textBoxes[i].Text;
            }
        }
    }
}
