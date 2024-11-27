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
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using ManagamentLibrary.Controller;
using ManagamentLibrary.Models;

namespace ManagamentLibrary
{
    /// <summary>
    /// Interaction logic for EmailAuthentication.xaml
    /// </summary>
    public partial class EmailAuthentication : Window
    {
        private readonly SignUp _signUp;
        private ForgotPassword _forgotPassword;
        private string? generatedCode; // biến thành viên dùng chung

        private readonly string verificationPurpose;  // verificationPurpose : Mục đích xác minh
        private readonly EmailAuthenticationController _emailAuthenticationController;
        public EmailAuthentication(string purpose, SignUp signUp, ForgotPassword forgotPassword)
        {
            _signUp = signUp;
            _forgotPassword = forgotPassword;
            _emailAuthenticationController = new EmailAuthenticationController();
            verificationPurpose = purpose;
            InitializeComponent();
            Email_Authentication_Content.Content = verificationPurpose == "SignUp"
                 ? _signUp.EmailTextBox.Text
                 : _forgotPassword.EmailTextBox.Text;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public string EmailContent { get =>  Email_Authentication_Content.Content.ToString()!; }

        private void btnArrow_Click(object sender, RoutedEventArgs e)
        {
            if(verificationPurpose == "SignUp")
            {
               _signUp.Show();
                this.Close();
            }
            else
            {
                _forgotPassword.Show();
                this.Close();
            }
           
        }

        //hàm tạo số ngẫu nhiên
        private string RandomCode()
        {
            Random random = new Random();
            return random.Next(100000,999999).ToString();
        } 
        
        private void SendCode_Click (object sender, RoutedEventArgs e)
        {
            generatedCode = RandomCode();

            string email = verificationPurpose == "SignUp"
                ? _signUp.EmailTextBox.Text
                : _forgotPassword.EmailTextBox.Text;

            if (verificationPurpose == "SignUp") {
                if (_emailAuthenticationController.SendVerificationEmail(email, generatedCode))
                {
                    MessageBox.Show("Mã xác thực đã được gửi đến email của bạn.", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Không thể gửi mã xác nhận. Vui lòng thử lại sau.");
                }
            }
            else if (_emailAuthenticationController.ValidateEmailForForgotPassword(email)) // IsNullOrEmpty: trả về true nếu null , trả về false nếu khác null
            {
                if (_emailAuthenticationController.SendVerificationEmail(email, generatedCode))
                {
                    MessageBox.Show("Mã xác thục đã được gửi đến email của bạn.", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Không thể gửi mã xác nhận. Vui lòng thử lại sau.");
                }
            }
            else
            {
                MessageBox.Show("Email của bạn chưa được đăng ký!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConfirmCode_Click(object sender, RoutedEventArgs e)
        {
            if(txtConfirmCode.Text == generatedCode)
            {
                if (verificationPurpose =="SignUp") {
                    try
                    {
                        string username = _signUp.UsernameTextBox.Text;
                        string password = _signUp.PasswordTextBox.Password;
                        string email = _signUp.EmailTextBox.Text;
                        var user = new UserModel() {UserName=username,Password=password, Email = email };

                        _emailAuthenticationController.RegisterUser(user); 
                        MessageBox.Show("Xác thực email thành công", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        Login main = new Login();
                        main.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Xác thực email thành công, hãy đổi mật khẩu", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowTabChangePassword(); 
                    this.Hide(); 
                }
            }
            else
            {
                MessageBox.Show("Mã xác thực email không chính xác. Vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ShowTabChangePassword()
        {
            ForgotPassword forgotPassword = new ForgotPassword(this);
            forgotPassword.Show();
            forgotPassword.Label_EnterEmail.Visibility = Visibility.Collapsed;
            forgotPassword.EmailTextBox.Visibility = Visibility.Collapsed;
            forgotPassword.btn_NextForgotPassword.Visibility = Visibility.Collapsed;

            forgotPassword.Label_NewPassWord.Visibility = Visibility.Visible;
            forgotPassword.PasswordBox_NewPassWord.Visibility = Visibility.Visible;
            forgotPassword.TextBox_NewPassWord.Visibility = Visibility.Collapsed;
            forgotPassword.TogglePasswordVisibilityButton.Visibility = Visibility.Visible;

            forgotPassword.Label_Re_enterNewPassWord.Visibility = Visibility.Visible;
            forgotPassword.PasswordBox_Re_Enter_NewPassWord.Visibility = Visibility.Visible;
            forgotPassword.TextBox_Re_enterNewPassWord.Visibility = Visibility.Collapsed;
            forgotPassword.Toggle_Re_Enter_PasswordVisibilityButton.Visibility = Visibility.Visible;  
            
            forgotPassword.btn_ChangePassWord.Visibility = Visibility.Visible;
        }
    }
}
