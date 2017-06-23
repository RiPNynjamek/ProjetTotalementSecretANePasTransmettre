using System;
using System.Collections.Generic;
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
        public LoginPageView()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if(Model.Authentication.Authenticate(Login.Text, Password.Text))
            {
                View.MainPageView main = new View.MainPageView();
                //MainWindow main = new MainWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
            else
            {
                //Log error login
                ErrorLogin.Visibility = Visibility.Visible;
            }
        }
    }
}
