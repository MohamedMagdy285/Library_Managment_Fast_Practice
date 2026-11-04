using Library_Managment.BLL.Services;
using Library_Managment.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment.PL.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _author;

        public AuthorController(IAuthorRepository author)
        {
            _author = author;
        }
        public IActionResult Index(string search)
        {
            IEnumerable<Author> authors;
            if (string.IsNullOrWhiteSpace(search))
                authors = _author.GetAll();
            else
                authors = _author.SearchByName(search);

                return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);
            _author.Add(author);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id,string ViewName="Details")
        {
            if (id is null)
                return BadRequest();

            var author = _author.GetById(id.Value);

            if (author is null)
                return NotFound();

            return View(ViewName,author);
        }

        public IActionResult Edit(int id)
        {
            return Details(id,"Edit");
        }

        [HttpPost]
        public IActionResult Edit(int id,Author author)
        {
            if(id != author.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            return View(author);
           

            _author.Update(author);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(int id, Author author)
        {
            if (id != author.Id)
                return BadRequest();

            _author.Delete(author);
            return RedirectToAction(nameof(Index));
        }
    } 
}
