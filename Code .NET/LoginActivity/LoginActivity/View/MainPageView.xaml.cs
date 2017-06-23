using System;
using System.Windows;

namespace LoginActivity.View
{
    /// <summary>
    /// Logique d'interaction pour MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Window
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = ".txt",
                Filter = "All files (*.*)|*.*|Txt files (*.txt)|*.txt",
                Multiselect = true
            };

            Nullable<bool> result = dlg.ShowDialog();
            
            if (result.HasValue && result.Value)
            {
                Filename.Text = "";
                foreach (var item in dlg.SafeFileNames)
                {
                    Filename.Text += item+"\n";
                }
            }
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            // Send files to webservice
        }
    }
}
