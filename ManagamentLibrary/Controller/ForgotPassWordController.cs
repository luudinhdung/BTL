using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagamentLibrary.Controller
{
    public class ForgotPassWordController
    {
        public ForgotPassWordController() { }
        public static void UpdatePassWord(string newPassWord, UserModel user)
        {
            var _userModel = new UserModel() {Email = user.Email};
            _userModel.UpdatePasswordUser(newPassWord);  
        }
    }
}
