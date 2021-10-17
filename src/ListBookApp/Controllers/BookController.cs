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
    }
}