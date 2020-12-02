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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = RegisterNameTextBox.Text;
            string email = RegisterEmailTextBox.Text;
            string password = RegisterPasswordBox.Password;
            string repeatPassword = RegisterRepeatPasswordBox.Password;
            if (password == repeatPassword)
            {
                UserService userService = new UserService();
                var isAdded = userService.AddUser(name, email, password);
                if (isAdded)
                {
                    MessageBox.Show("Registration successful!", "WorldOfWords", MessageBoxButton.OK, MessageBoxImage.Information);
                    Topics topics = new Topics();
                    topics.Show();
                    this.Close();
                    topics.UserNameLabel.Content = email;
                }
            }
            else
            {
                MessageBox.Show("Passwords don't match!", "WorldOfWords", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
