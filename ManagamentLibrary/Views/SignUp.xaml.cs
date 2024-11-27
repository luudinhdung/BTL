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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using ManagamentLibrary.Controller;

namespace ManagamentLibrary
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private readonly FocusController _focusController;
        private readonly SignUpController _signUpController;
        public SignUp()
        {
            InitializeComponent();
            _focusController = new FocusController();
            _signUpController = new SignUpController();
            UsernameTextBox.Text = "Tên đăng nhập"; 
            PasswordTextBox.Password = "Password";
            VisiblePasswordTextBox.Text = "Password";
            EmailTextBox.Text = "Email";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(UsernameTextBox, "Tên đăng nhập", Brushes.White);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(UsernameTextBox, "Tên đăng nhập", Brushes.White);
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandlePasswordBox_GotFocusLostFocus_Visible(PasswordTextBox,VisiblePasswordTextBox, "Password");    
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandlePasswordBox_GotFocusLostFocus_Visible(PasswordTextBox,VisiblePasswordTextBox, "Password");
        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(EmailTextBox,"Email", Brushes.White);
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(EmailTextBox, "Email", Brushes.White);
        }

        private void TogglePasswordVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            _focusController.Show_HidePasswords(PasswordTextBox,VisiblePasswordTextBox,TogglePasswordVisibilityButton, "1");
        }

        private void SignUpAdmin_Click(object sender, RoutedEventArgs e)
        {
            _signUpController.CheckTheDataFields(UsernameTextBox, PasswordTextBox, EmailTextBox);
            EmailAuthentication emailAuthentication = new EmailAuthentication("SignUp", this, null!);
            emailAuthentication.Show();
            this.Hide();
        }

        private void btnArrow_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

    }
}
