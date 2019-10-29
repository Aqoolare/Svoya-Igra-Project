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
using System.Windows.Shapes;
using SvoyaIgra;

namespace Svoya_Igra_Design
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        int NumberOfThemes;
        int NumberOfQuestions;
        Button[,] btns;
        TextBox[] textBoxes;
        private Config _configuration;
        public Game(Config Configuration)
        {
            InitializeComponent();

            _configuration = Configuration;

            NumberOfThemes = _configuration.Themes.Length;
            NumberOfQuestions = _configuration.Questions[1].Length;

            btns = new Button[NumberOfQuestions, NumberOfQuestions];
            textBoxes = new TextBox[NumberOfThemes];

            StartGame();
        }

        private void StartGame()
        {
            CreateColumn(124);
            for (int i = 0; i < NumberOfThemes; i++)
            {
                CreateRow(50);
                CreateTextBoxInTable(i);
                for (int j = 1; j <= NumberOfQuestions; j++)
                {
                    CreateColumn(101);
                    CreateButtonInTable(i, j);
                }
            }
        }

        private void CreateColumn(int width)
        {
            ColumnDefinition cd = new ColumnDefinition();
            cd.Width = new GridLength(width);
            GameGrid.ColumnDefinitions.Add(cd);
        }
        private void CreateRow(int height)
        {
            RowDefinition rd = new RowDefinition();
            rd.Height = new GridLength(height);
            GameGrid.RowDefinitions.Add(rd);
        }
        private void CreateTextBoxInTable(int i)
        {
            textBoxes[i].IsReadOnly = true;
            textBoxes[i] = new TextBox { Text = _configuration.Themes[i] };
            GameGrid.Children.Add(textBoxes[i]);
            Grid.SetRow(textBoxes[i], i);
            Grid.SetColumn(textBoxes[i], 0);
        }
        private void CreateButtonInTable(int i, int j)
        {
            btns[i, j - 1] = new Button { Content = j * 100 };
            GameGrid.Children.Add(btns[i, j - 1]);
            Grid.SetRow(btns[i, j - 1], i);
            Grid.SetColumn(btns[i, j - 1], j);
            btns[i, j - 1].Click += cell_Click;
        }
        void cell_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(sender as Button) - 1;
            int row = Grid.GetRow(sender as Button);
            btns[row, column].Click -= cell_Click;
            btns[row, column].Content = "";
            QuestionWindow QW = new QuestionWindow((Question)_configuration.Questions[row][column]);
        }
    }
}
