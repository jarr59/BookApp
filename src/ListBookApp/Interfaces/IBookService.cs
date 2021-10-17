using System.Collections.Generic;
using ListBookApp.Entites;
using ListBookApp.Models.Book;

namespace ListBookApp.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<AllBook> GetAll();
        public AllBook Create(CreateBook book);
        public EditBook Edit(EditBook book,int id);
        public void Delete(int id);
        public AllBook GetById(int id);
    }
}