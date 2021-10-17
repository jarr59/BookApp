using System.Collections.Generic;
using ListBookApp.Entites;
using ListBookApp.Models.Book;

namespace ListBookApp.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAll();
        public Book Create(CreateBook book);
    }
}