using ManagamentLibrary.Controller;
using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagamentLibrary.Views
{
    /// <summary>
    /// Interaction logic for ViewStudent.xaml
    /// </summary>
    public partial class ViewStudent : Window
    {
        private readonly StudentController _studentController;
        public ViewStudent()
        {
            InitializeComponent();

            _studentController = new StudentController();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visibility = Visibility.Hidden;
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

            _studentController.LoadData(dataGridView1);
        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridView1.SelectedItem is DataRowView currentRow) // DataRowView để truy cập vào dữ liệu hàng đã chọn
            {
                string? bkMSV = currentRow["MSV"].ToString();
                string? bkName = currentRow["Name"].ToString();
                string? bkClass = currentRow["Class"].ToString();

                MSV.Text = bkMSV;
                Name.Text = bkName;
                Class.Text = bkClass;

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
            _studentController.SearchStudent(TextBox_Search, dataGridView1);
        }

        //
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Search.Clear();
        }

        //update
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Data Will Be Update. Confirm", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                if (string.IsNullOrEmpty(Name.Text) ||
                     string.IsNullOrEmpty(Class.Text))
                {
                    MessageBox.Show("Please enter all data fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Chuyển đổi giá trị nhập vào thành các kiểu dữ liệu tương ứng
                string bkID = MSV.Text;
                string bkName = Name.Text;
                string bkAuthor = Class.Text;


                var student = new StudentModel()
                {
                    MSV = bkID,
                    Name = bkName,
                    Class = bkAuthor,
                };

                try
                {
                    _studentController.UpdateStudent(student);
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
                string bkId = MSV.Text;

                var student = new StudentModel() { MSV = bkId };

                try
                {
                    _studentController.DeleteStudent(student);
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
