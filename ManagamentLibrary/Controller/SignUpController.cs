using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ManagamentLibrary.Controller
{
    public class SignUpController
    {
        public SignUpController() 
        {
        }
        // kiểm tra định dạng email
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public void CheckTheDataFields (TextBox Username, PasswordBox Password, TextBox Email)
        {
            if (Username.Text == "Tên đăng nhập" || string.IsNullOrEmpty(Username.Text) ||
                Password.Password == "Password" || string.IsNullOrEmpty(Password.Password) ||
                //VisiblePasswordTextBox.Text == "Password" || string.IsNullOrEmpty(VisiblePasswordTextBox.Text) ||
                Email.Text == "Email" || string.IsNullOrEmpty(Email.Text)
                )
            {
                MessageBox.Show("Please enter all data fields and make sure no field is left with default text.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string email = Email.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email format is incorrect? Please re-enter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

    }
}
