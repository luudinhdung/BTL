using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagamentLibrary.Controller
{
    public class StudentController
    {
        public void LoadData(DataGrid dataGrid)
        {
            var student = new StudentModel();
            student.LoadData(dataGrid);
        }

        public void SaveStudent(StudentModel student)
        {
            var studentModel = new StudentModel() { 
                MSV = student.MSV,
                Name = student.Name,
                Class = student.Class,
            };
            studentModel.InsertStudent();
        }

        public void SearchStudent(TextBox textSeach, DataGrid grid)
        {
            var studentModel = new StudentModel();
            studentModel.SearchStudent(textSeach, grid);
        }

        public void UpdateStudent(StudentModel student)
        {
            var newStudent = new StudentModel()
            {
                MSV = student.MSV,
                Name = student.Name,
                Class = student.Class,
            };
            newStudent.UpdateStudent();
        }
        public void DeleteStudent(StudentModel student)
        {
            var student1 = new StudentModel() { MSV = student.MSV };
            student1.DeleteStudent();
        }
    }
}
