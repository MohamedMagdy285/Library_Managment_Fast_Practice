using AutoMapper;
using Library_Managment.BLL.Services;
using Library_Managment.DAL.Models;
using Library_Managment.PL.Helper;
using Library_Managment.PL.MappingProfiles;
using Library_Managment.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Managment.PL.Controllers
{
    public class BookController : Controller
    {
        private readonly IAuthorRepository _author;
        private readonly ICategoryRepository _category;
        private readonly IBookRepository _book;
        private readonly IMapper _mapper;

        public BookController(IAuthorRepository author, ICategoryRepository category,IBookRepository book,IMapper mapper)
        {
            _author = author;
            _category = category;
            _book = book;
            _mapper = mapper;
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            return _category.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
        }
        private void LoadDropDowns(BookViewModel vm)
        {
            vm.Authors = GetAuthor();
            vm.Categories = GetCategories();
        }
        private IEnumerable<SelectListItem> GetAuthor()
        {
            return _author.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
        }

        public IActionResult Index(string? search)
        {
            IEnumerable<Book> books;
            IEnumerable<BookViewModel> mappedBooks;
            if(string.IsNullOrWhiteSpace(search))            
                books = _book.GetBooksWithAuthorAndCategory(); 
            else
                books= _book.SearchbyName(search);

            mappedBooks = _mapper.Map<List<BookViewModel>>(books);
            return View(mappedBooks);
        }
        public IActionResult Create()
        {
            var vm = new BookViewModel
            {
                Authors = GetAuthor(),
                Categories = GetCategories()
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(BookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.ImageName = DocumentSettings.UploadFile(vm.Image, "images");
                vm.BookName = DocumentSettings.UploadFile(vm.Book, "pdf");
                var mappedbook = _mapper.Map<BookViewModel,Book>(vm);
                _book.Add(mappedbook);
            return RedirectToAction(nameof(Index));
            }
            LoadDropDowns(vm);
            return View(vm);
        }
        public IActionResult Details(int? id,string action="Details")
        {
            if (id is null)
                return BadRequest();
            var book = _book.GetBookWithAuthorAndCategory(id.Value);
            if (book is null)
                return NotFound();
            
            var mappedBook = _mapper.Map<Book, BookViewModel>(book);
            return View(action,mappedBook);
        }
        public IActionResult Download(string fileName)
        {
            var file = DocumentSettings.DownloadFile(fileName, "pdf");

            if (file == null)
                return NotFound();

            return file;
        }
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var book = _book.GetById(id.Value);
            if (id != book.Id)
                return NotFound();
            var mappedbook = _mapper.Map<Book, BookViewModel>(book);
            mappedbook.Authors = GetAuthor();
            mappedbook.Categories= GetCategories();
            return View(mappedbook);
        }
        [HttpPost]
        public IActionResult Edit(BookViewModel vm)
        {          
            if (ModelState.IsValid)
            {
                vm.ImageName = DocumentSettings.UploadFile(vm.Image, "images");
                vm.BookName = DocumentSettings.UploadFile(vm.Book, "pdf");
                var mappedbook = _mapper.Map<BookViewModel,Book>(vm);
                _book.Update(mappedbook);
                return RedirectToAction(nameof(Index));
            }
            LoadDropDowns(vm);
            return View(vm);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var book = _book.GetById(id.Value);
            if (id != book.Id)
                return NotFound();
            var mappedbook = _mapper.Map<Book, BookViewModel>(book);
            mappedbook.Authors = GetAuthor();
            mappedbook.Categories = GetCategories();
            return View(mappedbook);
        }
        //[HttpPost]
        //public IActionResult Delete(int? id,BookViewModel vm)
        //{
        //    if (id is null)
        //        return BadRequest();

        //    if (vm == null)
        //        return NotFound();

        //    if(id != vm.Id)
        //        return NotFound();

        //    var mappedbook = _mapper.Map<BookViewModel, Book>(vm);

        //    int count = _book.Delete(mappedbook);
        //    if (count > 0)
        //    {
        //    DocumentSettings.DeleteFile(vm.ImageName, "images");
        //    DocumentSettings.DeleteFile(vm.BookName, "pdf");
        //    return RedirectToAction(nameof(Index));
        //    }
        //    else
        //        return View(vm);
        //}
        [HttpPost]
        public IActionResult Delete(int? id, BookViewModel vm)
        {
            if (id is null)
                return BadRequest();

            if (id != vm.Id)
                return BadRequest();

            var book = _book.GetById(id.Value);

            if (book == null)
                return NotFound();

            DocumentSettings.DeleteFile(book.ImageName, "images");
            DocumentSettings.DeleteFile(book.BookName, "pdf");

            _book.Delete(book);

            return RedirectToAction(nameof(Index));
        }

    }
}
