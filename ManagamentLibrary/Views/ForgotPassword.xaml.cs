using ManagamentLibrary.Controller;
using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ManagamentLibrary
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {

        private EmailAuthentication _emailAuthentication;
        private readonly ForgotPassWordController _forgotPassWordController;
        private readonly FocusController _focusController;

        public ForgotPassword(EmailAuthentication emailAuthentication)
        {
            _emailAuthentication = emailAuthentication;
            _forgotPassWordController = new ForgotPassWordController();
            _focusController = new FocusController();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnArrow_Click(object sender, RoutedEventArgs e)
        {
            if (btn_NextForgotPassword.Visibility == Visibility.Visible)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                if(MessageBox.Show("Do you want to cancel password change?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
        }

        private void NextForgotPassword_Click (object sender, RoutedEventArgs e)
        {
            EmailAuthentication email = new EmailAuthentication("ForgotPassword", null! ,this);
            email.Show();
            this.Hide();
        }
        /*
         muốn gọi được Email_Authentication_Content.Content phải gọi 1 thuộc tính EmailContent trong EmailAuthentication 
        
        muốn lấy 1 cái thuộc tính nào từ bên b thì bên hàm khởi tạo bên a phải truyền 1 biến kiểu b vào và bên b cũng khỏi tạo 1 đối tượng a truyền this vào 
        để tham chiều các giá trị từ bên b sang bên a
         */
        private void ChangePassWord_Click(object sender, RoutedEventArgs e)
        {
            string email = _emailAuthentication.EmailContent;
            string newPass = PasswordBox_NewPassWord.Password;
            string reEnteredPass = PasswordBox_Re_Enter_NewPassWord.Password;
            var user = new UserModel() {Email =email };

            if(newPass == reEnteredPass && !string.IsNullOrEmpty(newPass)) 
            {
                try
                {
                    ForgotPassWordController.UpdatePassWord(newPass,user);
                    MessageBox.Show("Password has been changed successfully","Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    Login login = new Login();    
                    login.Show();
                    this.Close();
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The re-entered password does not match or is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    
        private void TogglePasswordVisibilityButton_Click(object sender, EventArgs e)
        {
            _focusController.Show_HidePasswords(PasswordBox_NewPassWord, TextBox_NewPassWord, TogglePasswordVisibilityButton, "");
        }

        private void Toggle_Re_Enter_PasswordVisibilityButton_Click(Object sender, EventArgs e)
        {
            _focusController.Show_HidePasswords(PasswordBox_Re_Enter_NewPassWord, TextBox_Re_enterNewPassWord, Toggle_Re_Enter_PasswordVisibilityButton, "");
        }
    }
}
