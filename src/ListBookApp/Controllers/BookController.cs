using ListBookApp.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ListBookApp.Controllers
{
    public class BookController : Controller
    {
        public BookDbContext _dbContext;
        public BookController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Books.ToList());   
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}