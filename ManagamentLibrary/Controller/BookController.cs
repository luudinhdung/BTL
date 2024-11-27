using ManagamentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagamentLibrary.Controller
{
    public class BookController
    {
        public void LoadData(DataGrid dataGrid)
        {
            var bookModel = new BookModel();
            bookModel.LoadData(dataGrid);
        }

        public void SaveBook(BookModel book)
        {
            var bookModel = new BookModel() { 
                Name = book.Name,
                Author = book.Author,
                Publication = book.Publication,
                PurchaseDate = book.PurchaseDate,
                Price = book.Price,
                Quantity = book.Quantity,
            };
            bookModel.InsertBook();
        }

        public void UpdateBook(BookModel book)
        {
            var bookModel = new BookModel()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Publication = book.Publication,
                PurchaseDate = book.PurchaseDate,
                Price = book.Price,
                Quantity = book.Quantity,
            };
            bookModel.UpdateBook();
        }

        public void DeleteBook(BookModel book) 
        {
            var bookModel = new BookModel(){Id = book.Id};
            bookModel.DeleteBook();
        }

        public void SearchBook(TextBox textSeach, DataGrid grid) {
            var bookModel = new BookModel();
            bookModel.SearchBook(textSeach,grid);
        }


    }
}
