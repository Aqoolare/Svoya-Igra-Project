using System;
using System.Windows;
using System.Windows.Threading;

namespace Svoya_Igra_Design
{
    public partial class QuestionWindow : Window
    {
        public GameWindow GameWindow;
        private Question _question;
        private DispatcherTimer timer;
        private ThisMove MoveResults = ThisMove.Null;
        private int QuestionCost;

        public QuestionWindow(GameWindow gamewindow, Question question, int cost)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _question = question;
            GameWindow = gamewindow;
            QuestionCost = cost;

            QuestionTextBox.Focusable = false;
            AnswerTextBox.Focusable = false;
            TimeTB.Focusable = false;
            QuestionTextBox.Text = _question.Content;
            AnswerTextBox.Text = _question.Answer;
            TimeTB.Text = "120";
            AnswerTextBox.Visibility = Visibility.Hidden;
            RightAnswerButton.Visibility = Visibility.Hidden;
            WrongAnswerButton.Visibility = Visibility.Hidden;
            OKButton.Visibility = Visibility.Hidden;

            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            int count = int.Parse(TimeTB.Text);
            count--;
            TimeTB.Text = count.ToString();
            if (count == 0)
            {
                timer.Stop();
                MoveResults = ThisMove.TimeOut;
                GiveAnswerButton.Visibility = Visibility.Hidden;
                AnswerTextBox.Visibility = Visibility.Visible;
                OKButton.Visibility = Visibility.Visible;
            }
        }
        private void WriteAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            GiveAnswerButton.Visibility = Visibility.Hidden;
            AnswerTextBox.Visibility = Visibility.Visible;
            RightAnswerButton.Visibility = Visibility.Visible;
            WrongAnswerButton.Visibility = Visibility.Visible;
        }
        private void WrongAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            MoveResults = ThisMove.WrongAnswer;
            AnswerIsGiven();
        }
        private void RightAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            MoveResults = ThisMove.RightAnswer;
            AnswerIsGiven();
        }
        void AnswerIsGiven()
        {
            RightAnswerButton.Visibility = Visibility.Hidden;
            WrongAnswerButton.Visibility = Visibility.Hidden;
            OKButton.Visibility = Visibility.Visible;
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoveResults == ThisMove.TimeOut || MoveResults == ThisMove.WrongAnswer)
            {
                GameWindow._players[GameWindow.NumberOfTeam].Score -= QuestionCost;
            }
            else
            {
                if (MoveResults == ThisMove.RightAnswer)
                {
                    GameWindow._players[GameWindow.NumberOfTeam].Score += QuestionCost;
                }
            }
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MoveResults == ThisMove.Null)
            {
                if (MessageBox.Show("Если вы закроете окно, то будет засчитан неверный ответ.\r\n Вы действительно хотите выйти?", "Справка", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    MoveResults = ThisMove.WrongAnswer;
                    GameWindow._players[GameWindow.NumberOfTeam].Score -= QuestionCost;
                    DialogResult = true;
                }
            }
        }
    }
    enum ThisMove
    {
        Null, RightAnswer, WrongAnswer, TimeOut
    }
}
