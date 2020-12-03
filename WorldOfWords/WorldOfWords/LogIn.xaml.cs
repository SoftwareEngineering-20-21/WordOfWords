using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorldOfWords
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogInBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogInButton_Click_1(object sender, RoutedEventArgs e)
        {
            string email = LogInEmailBox.Text;
            string password = LogInPasswordBox.Password;
            UserService user = new UserService();
            int id = user.VerifyUser(email, password);
            if (id != -1)
            {
                MessageBox.Show("Login successful!", "WorldOfWords", MessageBoxButton.OK, MessageBoxImage.Information);
                Topics topics = new Topics(id);
                topics.Show();
                this.Hide();
                topics.UserNameLabel.Content = email;
            }
            else
            {
                MessageBox.Show("Incorrect login or password!", "WorldOfWords", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
