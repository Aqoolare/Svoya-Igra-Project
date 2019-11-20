using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Svoya_Igra_Design
{
    public partial class RecordsWindow : Window
    {
        public RecordsWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = File.OpenRead("Records.txt"))
            {
                List<Player> DeserPlayers = (List<Player>)binFormat.Deserialize(fStream);
                DeserPlayers.Sort();
                foreach (var item in DeserPlayers)
                {
                    RecordListBox.Items.Add($"{item.Name}   {item.NameOfTheGame}    {item.Score}");
                }
                fStream.Close();
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }
    }
}
