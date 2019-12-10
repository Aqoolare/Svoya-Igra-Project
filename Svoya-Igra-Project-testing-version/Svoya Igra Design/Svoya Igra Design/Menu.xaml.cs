using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Svoya_Igra_Design
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private Dictionary<string, string> themes;
        public Menu()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            themes = new Dictionary<string, string>()
            {
                {"Светлая тема", "LightTheme" },
                {"Тёмная тема", "DarkTheme" }
            };
            List<string> styles = new List<string> { "Тёмная тема", "Светлая тема" };
            themeCBox.SelectionChanged += ThemeChange;
            themeCBox.ItemsSource = styles;
            themeCBox.SelectedItem = "Тёмная тема";
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = themes[themeCBox.SelectedItem as string];
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary resDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resDict);
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            PreCreateGameWindow pgw = new PreCreateGameWindow(themeCBox);
            pgw.ShowDialog();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Config cfg;
            openFileDialog.Filter = "New Game Configuration files (*.dat)|*NewGameConfig.dat";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Svoya Igra Design\bin\Debug\";
            string FileName = "";
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                cfg = DeserializeCfg(FileName);

                CreateNewPlayersWindow CNPW = new CreateNewPlayersWindow(FileName, cfg.Themes.Length * cfg.Questions[0].Length);
                if (CNPW.ShowDialog() == true)
                {
                    GameWindow GW = new GameWindow(CNPW.pList, cfg);
                    GW.ShowDialog();
                }
            }
        }

        public Config DeserializeCfg(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            Config configuration = new Config();

            using (Stream fStream = File.OpenRead(fileName))
            {
                try
                {
                    configuration = (Config)binFormat.Deserialize(fStream);
                }
                catch
                {
                    MessageBox.Show("Выберите файл с правильной конфигурацией ()", "Справка");
                }
                fStream.Close();
            }
            return configuration;
        }

        private NotCompletedGameCfg DeserializeNCGCfg(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            NotCompletedGameCfg configuration = new NotCompletedGameCfg();

            using (Stream fStream = File.OpenRead(fileName))
            {
                try
                {
                    configuration = (NotCompletedGameCfg)binFormat.Deserialize(fStream);
                }
                catch
                {
                    MessageBox.Show("Выберите файл с правильной конфигурацией ()", "Справка");
                }
            }
            return configuration;
        }

        private void RecordsButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Records.txt") == true)
            {
                StreamReader sr = new StreamReader("Records.txt");
                if (sr.ReadToEnd() != "")
                {
                    RecordsWindow RW = new RecordsWindow();
                    RW.ShowDialog();
                }
                else
                {
                    MessageBox.Show("У вас еще нет рекордов.", "Справка");
                }
            }
            else
            {
                MessageBox.Show("У вас еще нет рекордов.", "Справка");
            }
        }

        private void ContinueGameButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            NotCompletedGameCfg NCGcfg;
            openFileDialog.Filter = "Configuration files of not completed games (*.dat)|*NCGConfig.dat";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Svoya Igra Design\bin\Debug\";
            string FileName = "";
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                NCGcfg = DeserializeNCGCfg(FileName);
                GameWindow GW = new GameWindow(NCGcfg);
                GW.ShowDialog();        
            }
        }
    }
}
