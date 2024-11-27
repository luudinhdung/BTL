using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ManagamentLibrary.Models;

namespace ManagamentLibrary.Controller
{
    public class EmailAuthenticationController
    {
        private readonly EmailServiceModel _emailService;
        public EmailAuthenticationController() 
        {
            _emailService = new EmailServiceModel();
        }
        public bool ValidateEmailForForgotPassword(string email)
        {
            return _emailService.IsEmailRegistered(email);
        }

        public bool SendVerificationEmail(string email, string verificationCode)
        {
            return _emailService.SendVerificationEmail(email, verificationCode);
        }

        public void RegisterUser(UserModel user)
        {
            var _userModel = new UserModel() {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
            };
            _userModel.CreateUser();
        }
    }
}
