using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace Svoya_Igra_Design
{
    public partial class GameWindow : Window
    {
        private int NumberOfThemes;
        private int NumberOfQuestions;
        private Button[,] btns;
        private TextBox[] textBoxes;
        private Config _configuration;
        public List<Player> _players;
        public int NumberOfTeam = 0;
        private int NumberOfMotion = 1;
        private bool LastMotion = false;

        public GameWindow(List<Player> Players, Config Configuration)
        {
            InitializeWindow();

            _configuration = Configuration;
            _players = Players;

            InitializeTableParameters();

            StartGame();
        }

        public GameWindow(NotCompletedGameCfg ncgcfg)
        {
            InitializeWindow();

            _configuration = ncgcfg.Cfg;
            _players = ncgcfg.Players;
            NumberOfMotion = ncgcfg.NumberOFMotion;
            NumberOfTeam = ncgcfg.NumberOfTeam;

            InitializeTableParameters();

            StartGame();
        }

        private void InitializeWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Closing += OnClosing;
        }

        private void InitializeTableParameters()
        {
            TextBoxMove.Focusable = false;

            NumberOfThemes = _configuration.Themes.Length;
            NumberOfQuestions = _configuration.Questions[0].Length;

            btns = new Button[NumberOfThemes, NumberOfQuestions];
            textBoxes = new TextBox[NumberOfThemes];
            TextBoxMove.Text = "Ход команды: " + _players[NumberOfTeam].Name;
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
            ColumnDefinition cd = new ColumnDefinition
            {
                Width = new GridLength(width)
            };
            GameGrid.ColumnDefinitions.Add(cd);
        }

        private void CreateRow(int height)
        {
            RowDefinition rd = new RowDefinition
            {
                Height = new GridLength(height)
            };
            GameGrid.RowDefinitions.Add(rd);
        }

        private void CreateTextBoxInTable(int i)
        {
            textBoxes[i] = new TextBox { Text = _configuration.Themes[i] };
            textBoxes[i].Focusable = false;
            GameGrid.Children.Add(textBoxes[i]);
            Grid.SetRow(textBoxes[i], i);
            Grid.SetColumn(textBoxes[i], 0);
        }

        private void CreateButtonInTable(int i, int j)
        {
            if (!_configuration.Questions[i][j - 1].Checked)
            {
                btns[i, j - 1] = new Button { Content = j * 100 };
                GameGrid.Children.Add(btns[i, j - 1]);
                Grid.SetRow(btns[i, j - 1], i);
                Grid.SetColumn(btns[i, j - 1], j);
                btns[i, j - 1].Click += Cell_Click;
            }
            else
            {
                btns[i, j - 1] = new Button { Content = "" };
                GameGrid.Children.Add(btns[i, j - 1]);
                Grid.SetRow(btns[i, j - 1], i);
                Grid.SetColumn(btns[i, j - 1], j);
            }
        }

        void Cell_Click(object sender, RoutedEventArgs e)
        {
            if (NumberOfMotion == NumberOfThemes * NumberOfQuestions)
            {
                LastMotion = true;
            }
            NumberOfMotion++;
            int column = Grid.GetColumn(sender as Button) - 1;
            int row = Grid.GetRow(sender as Button);
            QuestionWindow QW = new QuestionWindow(this, (Question)_configuration.Questions[row][column], (int)btns[row, column].Content);
            QW.ShowDialog();
            btns[row, column].Click -= Cell_Click;
            btns[row, column].Content = "";
            _configuration.Questions[row][column].Checked = true;
            if (LastMotion)
            {
                EndOfGame();
            }
            else
            {
                NumberOfTeam = (NumberOfTeam + 1) % _players.Count;
                TextBoxMove.Text = "Ход команды: " + _players[NumberOfTeam].Name;
            }
        }

        void EndOfGame()
        {
            EndGameWindow Window = new EndGameWindow(_players);
            Window.ShowDialog();
            this.Close();
        }

        private void SerializeNotCompletedGame()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            NotCompletedGameCfg cfg = new NotCompletedGameCfg(_configuration, _players, NumberOfTeam, NumberOfMotion);
            using (Stream fStream = new FileStream(string.Format("({0})({1})({2})({3})({4})NCGConfig.dat", DateTime.Today.Day,DateTime.Today.Month,DateTime.Today.Year,DateTime.Now.TimeOfDay.Minutes,DateTime.Now.TimeOfDay.Seconds), FileMode.Create))
            {
                binFormat.Serialize(fStream, cfg);
                fStream.Close();
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs cancelEventArgs)
        {
            if (LastMotion == false)
            {
                MessageBoxResult result = MessageBox.Show(this, "Незавершенная игра будет сохранена. Вы действительно хотите выйти?", "Справка", MessageBoxButton.YesNo);
                if (result != MessageBoxResult.Yes)
                {
                    cancelEventArgs.Cancel = true;
                }
                else 
                {
                    SerializeNotCompletedGame();
                }
            }
        }
    }
}
