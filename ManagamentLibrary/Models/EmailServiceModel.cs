using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace ManagamentLibrary.Models
{
    public class EmailServiceModel
    {
        private readonly string connect = "Data Source=DESKTOP-2AK902G\\MSSQLSERVER2022;Initial Catalog=management library;User ID=sa;Password=123";

        public bool SendVerificationEmail(string recipientEmail, string verificationCode)
        {
            string senderEmail = "quanlythuvien0@gmail.com";
            string senderPassword = "amfo qqzf pelh qcak";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = "Xác Nhận Email hoạt động";
            mail.Body = $"Mã xác thực của bạn là : {verificationCode}";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // kiểm tra xem email tồn tại hay chưa
        public bool IsEmailRegistered(string email)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                string sql = "SELECT email FROM loginTable WHERE email COLLATE SQL_Latin1_General_CP1_CS_AS = @Email";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }
    }
}
