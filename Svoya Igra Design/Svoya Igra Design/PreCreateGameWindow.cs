using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Microsoft.Win32;

namespace Svoya_Igra_Design
{
    /// <summary>
    /// Interaction logic for PreCreateGameWindow.xaml
    /// </summary>
    public partial class PreCreateGameWindow : Window
    {
        public PreCreateGameWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CreateNewGameButton_Click(object sender, RoutedEventArgs e)
        {
            CreateGameWindow CGW = new CreateGameWindow();
            CGW.ShowDialog();
        }

        private void DownloadExcistingConfiguration_Click(object sender, RoutedEventArgs e)
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
                CreateGameWindow CGW = new CreateGameWindow(cfg);
                CGW.ShowDialog();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }
    }
}
