using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Svoya_Igra_Design
{
    public partial class EndGameWindow : Window
    {
        private List<Player> ListOfPlayers;

        public EndGameWindow(List<Player> listplayers)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TextBox.Focusable = false;

            ListOfPlayers = listplayers;

            Congretulations();
        }

        private void Congretulations()
        {
            ListOfPlayers.Sort();
            List<Player> ListOfWiners = (from f in ListOfPlayers where f.Score == ListOfPlayers[0].Score select f).ToList();
            TextBox.Text = "Урааааа, поздравляем победителей!!!\r\n В ожесточенной борьбе ";
            if (ListOfWiners.Count == 1)
            {
                TextBox.Text += "выигрывает \r\n команда: " + ListOfPlayers[0].Name;
                TextBox.Text += "\r\n Со счётом: " + ListOfPlayers[0].Score;
            }
            else
            {
                TextBox.Text += "выигрывают \r\n команды: ";
                foreach (var player in ListOfWiners)
                {
                    TextBox.Text += player.Name + " ";
                }
                TextBox.Text += "\r\n С одинаковым количеством очков: " + ListOfWiners[0].Score;
            }
            if (ListOfWiners.Count < ListOfPlayers.Count)
            {
                TextBox.Text += "\r\n\r\n ----------------------\r\n\r\n";
                for (int i = ListOfWiners.Count; i < ListOfPlayers.Count; i++)
                {
                    TextBox.Text += ListOfPlayers[i].Name + ":  " + ListOfPlayers[i].Score + "\r\n";
                }
            }
        }

        private void SerializationMethod()
        {
            List<Player> players = ListOfPlayers;
            BinaryFormatter binFormat = new BinaryFormatter();
            if (File.Exists("Records.txt"))
            {
                using (Stream fStream = File.OpenRead("Records.txt"))
                {
                    try
                    {
                        List<Player> DeserPlayers = (List<Player>)binFormat.Deserialize(fStream);
                        foreach (var item in DeserPlayers)
                        {
                            players.Add(new Player(item.Name, item.NameOfTheGame, item.Score));
                        }
                    }
                    catch
                    {

                    }
                    fStream.Close();
                }
            }
            using (Stream fStream = new FileStream("Records.txt", FileMode.OpenOrCreate))
            {
                binFormat.Serialize(fStream, players);
                fStream.Close();
            }
            MessageBox.Show("Все результаты сохранены", "Справка");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SerializationMethod();
            DialogResult = true;
        }
    }
}
