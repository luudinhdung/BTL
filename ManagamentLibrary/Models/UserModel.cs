using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagamentLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        private readonly string connect = "Data Source=DESKTOP-2AK902G\\SQLEXPRESS;Initial Catalog=management library;User ID=sa;Password=Password123";
       
        // login
        public bool ValidateUser()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                string sql = @"SELECT COUNT(1) from loginTable 
                               WHERE username COLLATE SQL_Latin1_General_CP1_CS_AS = @username 
                               AND pass COLLATE SQL_Latin1_General_CP1_CS_AS = @pass";
                using(SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.Parameters.AddWithValue("@username", UserName);
                    cmd.Parameters.AddWithValue("@pass", Password);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // thêm user
        public void CreateUser()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                string sql = "INSERT INTO loginTable (username, pass, email) VALUES (@username, @password, @Email)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", UserName);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // update password mới

        public void UpdatePasswordUser(string newPassWord)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();

                string sqlUpdatePassWord = "UPDATE loginTable SET pass = @newPass Where email = @email";
                using (SqlCommand cmd = new SqlCommand(sqlUpdatePassWord, con))
                {
                    cmd.Parameters.AddWithValue("newPass", newPassWord);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
