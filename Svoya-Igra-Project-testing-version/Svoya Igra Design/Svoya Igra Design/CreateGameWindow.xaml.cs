using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;

namespace Svoya_Igra_Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CreateGameWindow : Window
    {
        Config cfg;
        Button[,] btns;
        TextBox[] textBoxes;
        int column;
        int row;
        int numberOfThemes;
        int numberOfColumns;
        bool cellChecked = false;
        bool gameSaved = false;
        ComboBox tCBOX;

        public CreateGameWindow(ComboBox themeCBox)
        {
            InitializeWindow();
            tCBOX = themeCBox;
        }

        public CreateGameWindow(Config c, ComboBox themeCBox)
        {
            InitializeWindow();
            
            cfg = c;
            tCBOX = themeCBox;
            textBoxes = new TextBox[cfg.Themes.Length];
            for (int i = 0; i < cfg.Themes.Length; i++)
            {
                textBoxes[i] = new TextBox { Text = cfg.Themes[i] };
            }

            questionCostSlider.Value = cfg.Questions[0].Length;
            questionThemeSlider.Value = cfg.Themes.Length;

            createTableButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void InitializeWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Closing += OnClosing;
        }

        private void CreateTableButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTable();
            CreateColumn(250);

            questionContentTextBox.Text = "Введите вопрос";
            textBoxForRightAnswer.Text = "Введите правильный ответ";

            cellChecked = false;
            gameSaved = false;

            EnableConnectedControls();

            numberOfThemes = (int)questionThemeSlider.Value;
            numberOfColumns = (int)questionCostSlider.Value;

            CreateElementsOfTable(numberOfThemes, numberOfColumns);

            for (int i = 0; i < questionThemeSlider.Value; i++)
            {
                CreateRow(115);
                CreateTextBoxInTable(i);

                for (int j = 1; j <= questionCostSlider.Value; j++)
                {
                    CreateColumn(165);
                    CreateButtonInTable(i, j);
                }
            }
        }

        private void CreateElementsOfTable(int numberOfThemes, int numberOfColumns)
        {
            if (cfg == null)
            {
                cfg = new Config(numberOfThemes, numberOfColumns);
                textBoxes = new TextBox[numberOfThemes];
            }
            else
            {
                var tempCfg = cfg;
                cfg = new Config(numberOfThemes, numberOfColumns);
                var tempTBoxes = textBoxes;
                textBoxes = new TextBox[numberOfThemes];
                if (tempTBoxes.Length <= textBoxes.Length)
                    Array.Copy(tempTBoxes, textBoxes, tempTBoxes.Length);
                else
                    Array.Copy(tempTBoxes, textBoxes, textBoxes.Length);

                for (int i = 0; i < numberOfThemes; i++)
                {
                    if (tempCfg.Questions.Keys.Contains(i))
                    {
                        if (numberOfColumns <= tempCfg.Questions[i].Length)
                        {
                            for (int j = 0; j < numberOfColumns; j++)
                            {
                                cfg.Questions[i][j] = tempCfg.Questions[i][j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < tempCfg.Questions[i].Length; j++)
                            {
                                cfg.Questions[i][j] = tempCfg.Questions[i][j];
                            }
                        }
                    }
                }
            }
            btns = new Button[numberOfThemes, numberOfColumns];
        }

        private void EnableConnectedControls()
        {
            questionSaveButton.IsEnabled = true;
            createGameButton.IsEnabled = true;
            questionContentTextBox.IsEnabled = true;
            textBoxForRightAnswer.IsEnabled = true;
        }

        private void ClearTable()
        {
            questionsGrid.Children.Clear();
            questionsGrid.ColumnDefinitions.Clear();
            questionsGrid.RowDefinitions.Clear();
        }

        private void CreateColumn(int width)
        {
            ColumnDefinition cd = new ColumnDefinition
            {
                Width = new GridLength(width)
            };
            questionsGrid.ColumnDefinitions.Add(cd);
        }

        private void CreateRow(int height)
        {
            RowDefinition rd = new RowDefinition
            {
                Height = new GridLength(height)
            };
            questionsGrid.RowDefinitions.Add(rd);
        }

        private void CreateTextBoxInTable(int i)
        {
            if (textBoxes[i] == null)
            {
                textBoxes[i] = new TextBox { Text = "Название темы ;)" };
            }
            else
            {
                textBoxes[i] = new TextBox { Text = textBoxes[i].Text };
            }
            textBoxes[i].MouseDoubleClick += ThemesTextBox_MouseDoubleClick;
            questionsGrid.Children.Add(textBoxes[i]);
            Grid.SetRow(textBoxes[i], i);
            Grid.SetColumn(textBoxes[i], 0);
        }

        private void ThemesTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (sender as TextBox).Clear();
        }

        private void CreateButtonInTable(int i, int j)
        {
            btns[i, j - 1] = new Button { Content = j * 100 };
            questionsGrid.Children.Add(btns[i, j - 1]);
            Grid.SetRow(btns[i, j - 1], i);
            Grid.SetColumn(btns[i, j - 1], j);
            btns[i, j - 1].Click += Cell_Click;
        }

        int previousRowForBrush = 0;
        int previousColumnForBrush = 0;

        void Cell_Click(object sender, RoutedEventArgs e)
        {
            column = Grid.GetColumn(sender as Button) - 1;
            row = Grid.GetRow(sender as Button);
            cellChecked = true;

            BrushSelectedCell();

            ShowQuestionContent(row, column);
            ShowAnswerContent(row, column);
        }

        private void BrushSelectedCell()
        {
            if (previousColumnForBrush <= numberOfColumns - 1 && previousRowForBrush <= numberOfThemes - 1)
            {
                if (tCBOX.Text == "Тёмная тема")
                    btns[previousRowForBrush, previousColumnForBrush].Background = new SolidColorBrush(Color.FromArgb(255, 25, 34, 51));
                else
                    btns[previousRowForBrush, previousColumnForBrush].Background = new SolidColorBrush(Color.FromArgb(225, 173, 199, 228));
            }
            previousRowForBrush = row;
            previousColumnForBrush = column;
            btns[row, column].Background = Brushes.Gray;
        }

        private void ShowQuestionContent(int row, int column)
        {
            if (cfg.Questions[row][column].Content == null)
                questionContentTextBox.Text = string.Format("Введите вопрос для ячейки ;) (строка: {0}, столбец: {1})", row, column);
            else
                questionContentTextBox.Text = string.Format("{0} (строка: {1}, столбец: {2})", cfg.Questions[row][column].Content, row, column);
        }

        private void ShowAnswerContent(int row, int column)
        {
            if (cfg.Questions[row][column].Answer == null)
                textBoxForRightAnswer.Text = string.Format("Введите ответ для ячейки ;) (строка: {0}, столбец: {1})", row, column);
            else
                textBoxForRightAnswer.Text = string.Format("{0} (строка: {1}, столбец: {2})", cfg.Questions[row][column].Answer, row, column);
        }

        private void QuestionContentTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            questionContentTextBox.Clear();
        }

        private void QuestionSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (cellChecked)
            {
                cfg.Questions[row][column].Content = questionContentTextBox.Text;
                cfg.Questions[row][column].Answer = textBoxForRightAnswer.Text;

                MessageBox.Show(string.Format("{0} {1}", cfg.Questions[row][column].Content, cfg.Questions[row][column].Answer), $"Строка {row}, Столбец {column}");
            }
            else
            {
                MessageBox.Show("Сначала выберите клетку ;)", "Справка");
            }
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cfg.Themes.Length; i++)
            {
                cfg.Themes[i] = textBoxes[i].Text;
            }

            if (CheckTableOnEmptyCells() == false)
            {
                SerializeTable();
            }
        }

        private bool CheckTableOnEmptyCells()
        {
            bool questionIsEmpty = false;
            int emptyRowValue = 0;
            int emptyColumnValue = 0;

            for (int i = 0; i < numberOfThemes; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (cfg.Questions[i][j].Content == null || cfg.Questions[i][j].Answer == null 
                        || cfg.Questions[i][j].Content == "" || cfg.Questions[i][j].Answer == "")
                    {
                        questionIsEmpty = true;
                        emptyRowValue = i;
                        emptyColumnValue = j;
                        break;
                    }
                }
                if (questionIsEmpty)
                {
                    MessageBox.Show(string.Format("В вашей таблице содержится пустой вопрос :( (Строка {0}, столбец {1})", emptyRowValue, emptyColumnValue), "Справка");
                    break;
                }
            }

            return questionIsEmpty;
        }

        private void SerializeTable()
        {
            FileNameForm fNameForm = new FileNameForm();

            if (fNameForm.ShowDialog() == true)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(fNameForm.FileName, FileMode.Create))
                {
                    formatter.Serialize(fs, cfg);

                    if (MessageBox.Show("Игра сохранена!", "Справка") == MessageBoxResult.OK)
                    {
                        gameSaved = true;
                        DialogResult = true;
                    }
                }
            }
        }

        private void FreeQuestion_Checked(object sender, RoutedEventArgs e)
        {
            textBoxForRightAnswer.Visibility = Visibility.Visible;
        }

        private void TextBoxForRightAnswer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBoxForRightAnswer.Clear();
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (gameSaved == false)
            {
                if (MessageBox.Show(this, "Если вы закроете окно и не нажмёте кнопку СОХРАНИТЬ ТАБЛИЦУ, данные будут утеряны. Закрыть окно?", "Предупреждение", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                {
                    cancelEventArgs.Cancel = true;
                }
            }
        }

    }
}
