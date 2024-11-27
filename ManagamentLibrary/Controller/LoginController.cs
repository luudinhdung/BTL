using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagamentLibrary.Controller
{
    public class LoginController
    {

        private readonly Login _loginWindow;

        public LoginController(Login loginWindow)
        {
            _loginWindow = loginWindow;
        }

        public bool LoginAuthentication(UserModel user)
        {
            var _user = new UserModel()
            {
                UserName = user.UserName,
                Password = user.Password,
            };
            return _user.ValidateUser();
        }
    }
}
