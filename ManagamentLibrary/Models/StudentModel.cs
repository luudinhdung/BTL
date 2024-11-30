using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Data;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows;

namespace ManagamentLibrary.Models
{
    public class StudentModel
    {
        public string? MSV { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
       

        private readonly string connect = "Data Source=ADMIN-PC;Initial Catalog=management library;Integrated Security=True";

        public void LoadData(DataGrid grid)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open(); // Mở kết nối

                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt); // Lấy tất cả dữ liệu vào DataTable
                grid.ItemsSource = dt.DefaultView; // Hiển thị dữ liệu trong DataGrid
                con.Close();
            }
        }

        public void InsertStudent() 
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                string sqlQueryNewBK = "INSERT INTO Student (MSV, Name, Class) VALUES (@MSV, @Name, @Class)";

                using (SqlCommand command = new SqlCommand(sqlQueryNewBK, conn))
                {
                    // Gán tham số với kiểu dữ liệu chính xác
                    command.Parameters.Add(new SqlParameter("@MSV", SqlDbType.NVarChar) { Value = MSV });
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = Name });
                    command.Parameters.Add(new SqlParameter("@Class", SqlDbType.NVarChar) { Value = Class });

                    // Thực thi câu lệnh
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                conn.Close();
            }
        }
        public void SearchStudent(TextBox search, DataGrid grid)
        {
            if (!string.IsNullOrEmpty(search.Text))
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Name LIKE @searchText OR MSV LIKE @searchText", con);
                    cmd.Parameters.AddWithValue("@searchText", "%" + search.Text + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    grid.ItemsSource = dt.DefaultView;

                    con.Close();
                }
            }
            else
            {
                LoadData(grid);
            }
        }
        public void UpdateStudent()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                string sqlQueryNewBK = "UPDATE Student SET Name = @Name ,Class = @Class  WHERE MSV = @MSV ";

                using (SqlCommand command = new SqlCommand(sqlQueryNewBK, conn))
                {
                    command.Parameters.AddWithValue("@MSV", MSV);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("@Class", Class);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void DeleteStudent()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                string sqlQueryNewBK = "DELETE FROM Student WHERE MSV = @MSV";

                using (SqlCommand command = new SqlCommand(sqlQueryNewBK, conn))
                {
                    command.Parameters.AddWithValue("@MSV", MSV);

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

    }
}
