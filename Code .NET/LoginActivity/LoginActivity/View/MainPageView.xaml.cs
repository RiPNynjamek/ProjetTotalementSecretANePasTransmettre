using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace LoginActivity.View
{
    /// <summary>
    /// Logique d'interaction pour MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Window
    {
        private List<string> filenames;
        public MainPageView()
        {
            InitializeComponent();
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            if(filenames == null) filenames = new List<string>();
            if (filenames.Count > 0) filenames.Clear();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = ".txt",
                Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Multiselect = true
            };

            Nullable<bool> result = dlg.ShowDialog();
            
            if (result.HasValue && result.Value)
            {
                Filename.Text = "";
                foreach (var item in dlg.FileNames)
                {
                    Filename.Text += item+"\n";
                    filenames.Add(item);
                }
            }
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            if (Model.Decrypt.Decrypter(filenames))
            {
                // Success!
                Information.Text = "File decrypted successfully!";
            }
            else
            {
                // Fail
                Information.Text = "Error!";
            }
            
        }
    }
}
