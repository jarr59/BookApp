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
        public AllBook Create(CreateBook model)
        {
            var book = new Book
            {   
                Name = model.Name,
                ISBN = model.ISBN
            };

            _context.Add(book);

            _context.SaveChanges();

            return new AllBook{  
                IdBook = book.IdBook,
                Name = book.Name,
                ISBN = book.ISBN
            };
        }

        public void Delete(int id)
        {
            var bookSearched =_context.Books.Where(x=>x.IdBook==id).First();
            _context.Books.Remove(bookSearched);
            _context.SaveChanges();
        }

        public EditBook Edit(EditBook bookEdit, int id)
        {
            var bookSearched =_context.Books.Where(x=>x.IdBook==id).FirstOrDefault();
            if(bookSearched is not null)
            {
                bookSearched.Name = bookEdit.Name;
                bookSearched.ISBN = bookEdit.ISBN;
                _context.Entry(bookSearched).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return bookEdit;
            } 
            return null;
        }

        public IEnumerable<AllBook> GetAll()
        {
            List<AllBook> allBooks = new List<AllBook>();
            var books =_context.Books.ToList();
            for(int i = 0; i < _context.Books.Count(); i++)
            {
                allBooks.Add(new AllBook
                {
                    IdBook = books[i].IdBook,
                    Name = books[i].Name,
                    ISBN =books[i].ISBN
                });
            }   
            return allBooks;
        }

        public AllBook GetById(int id)
        {
            var book = _context.Books.Where(x=>x.IdBook == id).First();
            return new AllBook
            {
                IdBook = book.IdBook,
                Name = book.Name,
                ISBN = book.ISBN
            };
        }
    }
}