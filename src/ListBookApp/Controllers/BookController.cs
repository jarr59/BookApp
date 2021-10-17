using ListBookApp.Interfaces;
using ListBookApp.Models.Book;
using Microsoft.AspNetCore.Mvc;

namespace ListBookApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());   
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBook book)
        {
            if(ModelState.IsValid)
            {
                _service.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Edit([Bind]int? id)
        {
            if(id is null)
            {
                return NotFound();
            }
            var book = _service.GetById(id.Value);
            if(book is null)
            {
                return NotFound();
            }
            return View(new EditBook{
                IdBook = book.IdBook,
                Name = book.Name,
                ISBN =  book.ISBN
            });
        }
        [HttpPost]
        public IActionResult Edit(EditBook book)
        {
            if(ModelState.IsValid)
            {
                _service.Edit(book,book.IdBook);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Delete([Bind]int? id)
        {
            if(id is null)
            {
                return NotFound();
            }
            var book = _service.GetById(id.Value);
            if(book is null)
            {
                return NotFound();
            }
            return View(new DeleteBook{
                IdBook = book.IdBook,
                Name = book.Name,
                ISBN =  book.ISBN
            });
        }
        [HttpPost]
        public IActionResult Delete(DeleteBook book)
        {
            if(book == null)
            {
                return NotFound();
            }
            if(book.IdBook <= 0)
            {
                return NotFound();
            }
            _service.Delete(book.IdBook);
            return RedirectToAction(nameof(Index));
        }
    }
}