using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagamentLibrary.Controller
{
    public class DashBoardController
    {
        public void ShowOrActivateWindow<T>(ref T window) where T : Window, new()
        {
            if (window == null || !window.IsVisible)
            {
                window = new T();
                window.Show();
            }
            else
            {
                window.Activate();
            }
        }

    }
}
