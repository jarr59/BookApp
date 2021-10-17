using System.Collections.Generic;
using System.Linq;
using ListBookApp.Entites;
using ListBookApp.Models.Book;

namespace ListBookApp.Interfaces
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }
        public Book Create(CreateBook model)
        {
            var book = new Book
            {   
                Name = model.Name,
                ISBN = model.ISBN
            };

            _context.Add(book);

            _context.SaveChanges();

            return book;
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }
    }
}