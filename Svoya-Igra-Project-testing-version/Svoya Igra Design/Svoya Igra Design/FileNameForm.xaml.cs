using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Svoya_Igra_Design
{
    /// <summary>
    /// Interaction logic for FileNameForm.xaml
    /// </summary>
    public partial class FileNameForm : Window
    {
        public FileNameForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public string FileName { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fileNameTextBox.Text != null)
            {
                FileName = string.Format("{0}NewGameConfig.dat", fileNameTextBox.Text);
                if (File.Exists(Directory.GetCurrentDirectory() + @"\" + FileName) == false)
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Файл с таким именем уже существует, введите другое имя :)");
                }
            }
        }

        private void FileNameTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            fileNameTextBox.Clear();
        }
    }
}
