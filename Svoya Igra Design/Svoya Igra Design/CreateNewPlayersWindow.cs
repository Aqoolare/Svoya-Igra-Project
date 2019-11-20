using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Svoya_Igra_Design
{
    public partial class CreateNewPlayersWindow : Window
    {
        private string fileName;
        public List<Player> pList = new List<Player>();
        private int SizeOfTable;

        public CreateNewPlayersWindow(string file, int sizeoftable)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            fileName = file;
            SizeOfTable = sizeoftable;
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (pList.Count < SizeOfTable / 2 + SizeOfTable % 2)
            {
                string nameOfTheGame = System.IO.Path.GetFileName(fileName);
                pList.Add(new Player(PlayerTextBox.Text, nameOfTheGame, 0));
                PlayerListBox.Items.Add(PlayerTextBox.Text);
                PlayerTextBox.Text = "";
            }
            else AddPlayerButton.Click -= AddPlayerButton_Click;
        }

        private void CreatePlayerListButton_Click(object sender, RoutedEventArgs e)
        {
            if (pList.Count == 0)
            {
                MessageBox.Show("Добавьте игроков...", "Справка");
                return;
            }
            if (SizeOfTable % pList.Count != 0)
            {
                if (MessageBox.Show("Эта игра будет не честной (не все игроки смогут открыть равное количество ячеек). Все равно создать игру?", "Справка", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.DialogResult = true;
                }
            }
            else
            {
                this.DialogResult = true;
            }
        }

        private void PlayerTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerTextBox.Clear();
        }

        private void DeletePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (pList.Count > 0)
            {
                PlayerListBox.Items.RemoveAt(pList.Count - 1);
                pList.RemoveAt(pList.Count - 1);
            }
        }
    }
}
