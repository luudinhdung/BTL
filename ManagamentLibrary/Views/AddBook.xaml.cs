using ManagamentLibrary.Controller;
using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private readonly FocusController _focusController;

        private readonly BookController _bookController;
        public AddBook()
        {
            InitializeComponent();
            BookName.Text = "Nhập tên sách";
            AuthorName.Text = "Nhập tác giả";
            BookPublication.Text = "Nơi sản xuất";
            BookPrice.Text = "Nhập giá";
            BookQuantity.Text = "Nhập số lượng";

            _focusController = new FocusController();
            _bookController = new BookController();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BookName_GotFocus(object sender, RoutedEventArgs e)
        {
           _focusController.HandleTxtBox_GotFocusLostFocus(BookName,"Nhập tên sách",Brushes.Black);
        }

        private void BookName_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookName, "Nhập tên sách", Brushes.Black);
        }

        private void AuthorName_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(AuthorName, "Nhập tác giả", Brushes.Black);
        }

        private void AuthorName_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(AuthorName, "Nhập tác giả", Brushes.Black);
        }

        private void BookPublication_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookPublication, "Nơi sản xuất", Brushes.Black);
        }

        private void BookPublication_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookPublication, "Nơi sản xuất", Brushes.Black);
        }

        private void BookPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookPrice, "Nhập giá", Brushes.Black);
        }

        private void BookPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookPrice, "Nhập giá", Brushes.Black);

        }
        private void BookQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookQuantity, "Nhập số lượng", Brushes.Black);
        }

        private void BookQuantity_LostFocus(object sender, RoutedEventArgs e)
        {
            _focusController.HandleTxtBox_GotFocusLostFocus(BookQuantity, "Nhập số lượng", Brushes.Black);

        }

        private void ResetTextFields()
        {
            BookName.Text = "Nhập tên sách";
            BookName.Foreground = Brushes.Gray;

            AuthorName.Text = "Nhập tác giả";
            AuthorName.Foreground = Brushes.Gray;

            BookPublication.Text = "Nơi sản xuất";
            BookPublication.Foreground = Brushes.Gray;

            DateTimePicker.SelectedDate = null;

            BookPrice.Text = "Nhập giá";
            BookPrice.Foreground = Brushes.Gray;

            BookQuantity.Text = "Nhập số lượng";
            BookQuantity.Foreground = Brushes.Gray;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (BookName.Text == "Nhập tên sách" || string.IsNullOrEmpty(BookName.Text) ||
                AuthorName.Text == "Nhập tác giả" || string.IsNullOrEmpty(AuthorName.Text) ||
                BookPublication.Text == "Nơi sản xuất" || string.IsNullOrEmpty(BookPublication.Text) ||
                BookPrice.Text == "Nhập giá" || string.IsNullOrEmpty(BookPrice.Text) ||
                BookQuantity.Text == "Nhập số lượng" || string.IsNullOrEmpty(BookQuantity.Text) ||
                !DateTimePicker.SelectedDate.HasValue) 
            {
                MessageBox.Show("Please enter all data fields and make sure no field is left with default text.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Chuyển đổi giá trị nhập vào thành các kiểu dữ liệu tương ứng
            string bkName = BookName.Text;
            string bkAuthor = AuthorName.Text;
            string bkPublication = BookPublication.Text;
            string bkDate = DateTimePicker.Text;
            int bkPrice;
            int bkQuantity;

            // Kiểm tra giá trị giá sách và số lượng có phải là số hợp lệ không
            if (!int.TryParse(BookPrice.Text, out bkPrice) || bkPrice <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for price.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(BookQuantity.Text, out bkQuantity) || bkQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var book = new BookModel() {
                Name = bkName,
                Author = bkAuthor,
                Publication = bkPublication,
                PurchaseDate = bkDate,
                Price = bkPrice,
                Quantity = bkQuantity
            };

            try
            {
                _bookController.SaveBook(book);
                MessageBox.Show("Data Saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetTextFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancle?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
