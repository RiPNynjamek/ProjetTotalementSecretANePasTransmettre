using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using LoginActivity.Model;
using LoginActivity.Businness;
using System.Windows.Media;

namespace LoginActivity.View
{
    /// <summary>
    /// Logique d'interaction pour MainPageView.xaml
    /// </summary>
    public partial class MainPageView : Window
    {
        private List<string> filenames;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private readonly string REPORT_FILE_PATH = "D:\\fichier.pdf";

        public MainPageView()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;

        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            if (filenames == null) filenames = new List<string>();
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
                Filename.Content = "";
                foreach (var item in dlg.FileNames)
                {
                    Filename.Content += item + "\n";
                    filenames.Add(item);
                    SendFile.IsEnabled = true;
                }
            }
            else
            {
                Filename.Content = "";
                SendFile.IsEnabled = false;
            }
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            SendFile.IsEnabled = false;
            PdfFile.Visibility = Visibility.Hidden;
            PdfFile.IsEnabled = false;
            Loading.Visibility = Visibility.Visible;
            Information.Foreground = Brushes.Red;
            try
            {
                worker.RunWorkerAsync();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Information.Text = string.Empty;
            });
            if (Decrypt.Decrypter(filenames))
            {
                // Success!
                string message = "Message was successfully decrypted! The mail is : " + Decrypt.retour.Email + 
                    " and it was decrypted with the following key : " + Decrypt.retour.Key + ". The confidence rate is : " + Decrypt.retour.Confidence;
                FileCreation.CreatePDF(REPORT_FILE_PATH, message);
                Dispatcher.Invoke(() =>
                {
                    PdfFile.Visibility = Visibility.Visible;
                    PdfFile.IsEnabled = true;
                    Information.Foreground = Brushes.Green;
                });
                
            }
            Dispatcher.Invoke(() =>
            {
                Information.Text = Decrypt.InformationMessage;
                SendFile.IsEnabled = true;
                Loading.Visibility = Visibility.Hidden;
            });
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {

        }

        private void ListUsers(object sender, RoutedEventArgs e)
        {
            List<string> users = Model.Information.GetCurrentUsers() ?? new List<string>();
            Users.Content = "";
            foreach (var item in users)
            {
                Users.Content += item + "\n";
            }
        }

        private void PdfFile_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(REPORT_FILE_PATH);
        }
    }
}
