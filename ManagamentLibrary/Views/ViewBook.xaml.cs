using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using ManagamentLibrary.Controller;
using ManagamentLibrary.Models;

namespace ManagamentLibrary
{
    /// <summary>
    /// Interaction logic for ViewBook.xaml
    /// </summary>
    public partial class ViewBook : Window
    {
        private readonly BookController _bookController;
        public ViewBook()
        {
            InitializeComponent();

            _bookController = new BookController();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visibility = Visibility.Hidden;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

            _bookController.LoadData(dataGridView1);  
        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dataGridView1.SelectedItem is DataRowView currentRow) // DataRowView để truy cập vào dữ liệu hàng đã chọn
            {
                string? bkID = currentRow["bookId"].ToString();
                string? bkName = currentRow["bookName"].ToString();
                string? bkAuthor = currentRow["bookAuthor"].ToString();
                string? bkPulication = currentRow["bkPulication"].ToString();
                string? bkDate = currentRow["bookDate"].ToString();
                string? bkPrice = currentRow["bookPrice"].ToString();
                string? bkQuantity = currentRow["bkQuantity"].ToString();

                BookId_TextBox.Text = bkID;
                BkName_TextBox.Text = bkName;
                AuthorName_TextBox.Text= bkAuthor;
                Pulication_TextBox.Text = bkPulication ;
                DatePicker_TextBox.Text = bkDate;
                Price_TextBox.Text = bkPrice;
                Quantity_TextBox.Text= bkQuantity;

                // Cuộn màn hình đến phần TextBox
                ScrollViewer scrollViewer = (ScrollViewer)this.FindName("scrollViewer"); // Lấy ScrollViewer từ XAML
                if (scrollViewer != null)
                {
                    // Cuộn đến dưới cùng (cuộn đến cuối nội dung)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);

                }
            }
            panel2.Visibility = Visibility.Visible;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        // tìm kiếm dữ liệu
        private void Search_TxtChanged(object sender, EventArgs e)
        {
            _bookController.SearchBook(TextBox_Search,dataGridView1);
        }

        //
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Search.Clear();
        }

        //update
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Data Will Be Update. Confirm", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK) {
                if (string.IsNullOrEmpty(BkName_TextBox.Text) ||
                     string.IsNullOrEmpty(AuthorName_TextBox.Text) ||
                     string.IsNullOrEmpty(Pulication_TextBox.Text) ||
                     string.IsNullOrEmpty(Price_TextBox.Text) ||
                     string.IsNullOrEmpty(Quantity_TextBox.Text) ||
                    !DatePicker_TextBox.SelectedDate.HasValue)
                {
                    MessageBox.Show("Please enter all data fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Chuyển đổi giá trị nhập vào thành các kiểu dữ liệu tương ứng
                string bkID = BookId_TextBox.Text;
                string bkName = BkName_TextBox.Text;
                string bkAuthor = AuthorName_TextBox.Text;
                string bkPublication = Pulication_TextBox.Text;
                string bkDate = DatePicker_TextBox.Text;
                int bkPrice;
                int bkQuantity;

                // Kiểm tra giá trị giá sách và số lượng có phải là số hợp lệ không
                if (!int.TryParse(Price_TextBox.Text, out bkPrice) || bkPrice <= 0)
                {
                    MessageBox.Show("Please enter a valid positive number for price.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(Quantity_TextBox.Text, out bkQuantity) || bkQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid positive number for quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var book = new BookModel()
                {
                    Id = bkID,
                    Name = bkName,
                    Author = bkAuthor,
                    Publication = bkPublication,
                    PurchaseDate = bkDate,
                    Price = bkPrice,
                    Quantity = bkQuantity
                };

                try
                {
                   _bookController.UpdateBook(book);
                    MessageBox.Show("Data Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ViewBook_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //Delete    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Delete. Confirm", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                string bkId = BookId_TextBox.Text;

                var book = new BookModel(){Id = bkId};

                try
                {
                    _bookController.DeleteBook(book);
                    MessageBox.Show("Data Deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ViewBook_Load(sender, e);
                    buttonCancle_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
        private void buttonCancle_Click(object sender, EventArgs e)
        {
            panel2.Visibility = Visibility.Hidden;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }
    }
}
