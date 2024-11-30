using ManagamentLibrary.Controller;
using ManagamentLibrary.Models;
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

namespace ManagamentLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private readonly FocusController _focusController;
        private readonly StudentController _studentController;
        public AddStudent()
        {
            InitializeComponent();
            MSV.Text = "";
            Name.Text = "";
            Class.Text = "";

            _focusController = new FocusController();
            _studentController = new StudentController();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
   
        private void ResetTextFields()
        {
            MSV.Text = "";
            MSV.Foreground = Brushes.Gray;

            Name.Text = "";
            Name.Foreground = Brushes.Gray;

            Class.Text = "";
            Class.Foreground = Brushes.Gray;

        }
    
       
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MSV.Text == "Nhập MSV" || string.IsNullOrEmpty(MSV.Text) ||
                Name.Text == "Nhập tên sinh viên" || string.IsNullOrEmpty(Name.Text) ||
                Class.Text == "Nhập tên lớp" || string.IsNullOrEmpty(Class.Text) )
            {
                MessageBox.Show("Please enter all data fields and make sure no field is left with default text.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Chuyển đổi giá trị nhập vào thành các kiểu dữ liệu tương ứng
            string stMSV = MSV.Text;
            string StName = Name.Text;
            string StClass = Class.Text;

            

            var student = new StudentModel()
            {
                MSV = stMSV,
                Name = StName,
                Class = StClass,
            };

            try
            {
                _studentController.SaveStudent(student);
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
