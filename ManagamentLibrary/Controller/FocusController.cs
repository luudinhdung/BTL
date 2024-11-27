using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ManagamentLibrary.Controller
{
    public class FocusController
    {
        private bool isPasswordVisible = false;

        public void HandleTxtBox_GotFocusLostFocus(TextBox name, string content, Brush color)
        {
            if(name.Text == content)
            {
                name.Text = "";
                name.Foreground = color;
            }else if (string.IsNullOrEmpty(name.Text)) {
                name.Text = content;
                name.Foreground = Brushes.Gray;
            }
        }

        public void HandlePasswordBox_GotFocusLostFocus(PasswordBox name, string content , Brush color)
        {
            if (name.Password == content)
            {
                name.Clear();
                name.Foreground = color;
            }
            else if (string.IsNullOrEmpty(name.Password))
            {
                name.Password = content;
                name.Foreground = Brushes.Gray;
            }
        }

        public void HandlePasswordBox_GotFocusLostFocus_Visible(PasswordBox hiddenName, TextBox visibleName, string content)
        {
            if(hiddenName.Password == content && visibleName.Text == content)
            {
                hiddenName.Clear();
                visibleName.Clear();
                hiddenName.Foreground = Brushes.White;
                visibleName.Foreground = Brushes.White;
            }else if(string.IsNullOrEmpty(hiddenName.Password) && string.IsNullOrEmpty(visibleName.Text))
            {
                hiddenName.Password = content;
                visibleName.Text = content;
                hiddenName.Foreground = Brushes.Gray;
                visibleName.Foreground = Brushes.Gray;
            }
        }

        public void Show_HidePasswords(PasswordBox hiddenName, TextBox visibleName, Button btnName, string imgName)
        {
            if (isPasswordVisible)
            {
                hiddenName.Password = visibleName.Text;
                hiddenName.Visibility = Visibility.Visible;
                visibleName.Visibility = Visibility.Collapsed;
                isPasswordVisible = false;
                btnName.Content = new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/img/eye_open{imgName}.png"))
                };
            }
            else
            {
                // Chuyển từ chế độ ẩn sang hiển thị mật khẩu
                visibleName.Text = hiddenName.Password;
                hiddenName.Visibility = Visibility.Collapsed;
                visibleName.Visibility = Visibility.Visible;
                isPasswordVisible = true;
                btnName.Content = new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/img/eye_close{imgName}.png"))
                };
            }
        }
    }
}
