using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginActivity
{
    /// <summary>
    /// Logique d'interaction pour LoginPageView.xaml
    /// </summary>
    public partial class LoginPageView : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public LoginPageView()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
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
            string login = "", password = "";
            Dispatcher.Invoke(() =>
            {
                ErrorLogin.Visibility = Visibility.Hidden;
                login = Login.Text;
                password = Password.Text;
            });
            if (Model.Authentication.Authenticate(login, password))
            {
                Dispatcher.Invoke(() =>
                {
                    View.MainPageView main = new View.MainPageView();
                    App.Current.MainWindow = main;
                    this.Close();
                    main.Show();

                });
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    ErrorLogin.Text = Model.Authentication.InformationMessage;
                    ErrorLogin.Visibility = Visibility.Visible;
                });
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {

        }
    }
}
