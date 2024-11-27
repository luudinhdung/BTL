using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using ManagamentLibrary.Controller;
using System.Windows.Controls.Primitives;
using ManagamentLibrary.Models;

namespace ManagamentLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly FocusController _focusController;
        private readonly LoginController _mainController;
        public Login()
        {
            InitializeComponent();
            _focusController = new FocusController();
            _mainController = new LoginController(this);
            UsernameTextBox.Text = "Tên đăng nhập";
            PasswordTextBox.Password = "Password";

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
            _focusController.HandlePasswordBox_GotFocusLostFocus(PasswordTextBox, "Password", Brushes.White);
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandlePasswordBox_GotFocusLostFocus(PasswordTextBox, "Password", Brushes.White);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username  = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            var user = new UserModel()
            {
                UserName = username,
                Password = password
            };

            if (_mainController.LoginAuthentication(user))
            {
                DashBoard dashBoard = new DashBoard();
                dashBoard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignUpButton_Click(Object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword(null!);
            forgotPassword.Show();
            this.Close();
        }
    }
}