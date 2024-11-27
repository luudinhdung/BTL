using ManagamentLibrary.Controller;
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

namespace ManagamentLibrary
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        private AddBook addBook; // Biến để theo dõi cửa sổ AddBook

        private ViewBook viewBook;

        private readonly DashBoardController dashBoardController;
        public DashBoard()
        {
            InitializeComponent();
            addBook = new AddBook();
            viewBook = new ViewBook();
            dashBoardController = new DashBoardController();
            this.Closing += DashBoard_Closing;  // kiểm tra xem có của sổ con nào của dashboard chưa đóng hay không
        
        }

        private void DashBoard_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {

                if (window != this && window.IsVisible) // Nếu cửa sổ con vẫn còn mở
                {
                    MessageBox.Show("Please close all open pages before closing the dashboard.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    e.Cancel = true; 

                    return;
                }
                else
                {
                    e.Cancel = false;
                    return;
                }
            }
        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                var openWindows = Application.Current.Windows;

                Login main = new Login();
                main.Show();

                foreach (Window window in openWindows)
                {
                    if (window != main)
                    {
                        window.Close();
                    }
                }
            }
        }


        private void ClickAddBook(object sender, RoutedEventArgs e)
        {
            dashBoardController.ShowOrActivateWindow(ref addBook);
        }

        private void ClickViewBook(object sender, RoutedEventArgs e)
        {
            dashBoardController.ShowOrActivateWindow(ref viewBook);
        }

        
    }
}
