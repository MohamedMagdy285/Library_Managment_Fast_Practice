using AutoMapper;
using AutoMapper.Execution;
using Library_Managment.BLL.Services;
using Library_Managment.DAL.Models;
using Library_Managment.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Managment.PL.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IBorrowRepository _borrow;
        private readonly IMapper _mapper;
        private readonly IBookRepository _book;
        private readonly IMemberRepository _member;

        public BorrowController(IBorrowRepository borrow,IMapper mapper,IBookRepository book,IMemberRepository member)
        {
            _borrow = borrow;
            _mapper = mapper;
            _book = book;
            _member = member;
        }

        private IEnumerable<SelectListItem> GetBooks()
        {
            return _book.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                });
        }
        private IEnumerable<SelectListItem> GetMember()
        {
            return _member.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.FullName
                });
        }
        private void LoadDropDowns(BorrowViewModel vm)
        {
            vm.Books = GetBooks();
            vm.Members = GetMember();
        }
        public IActionResult Index()
        {
            var Borrows = _borrow.GetAllWithMemberAndBook();
            var mappedBorrows = _mapper.Map<IEnumerable<BorrowViewModel>>(Borrows);
            return View(mappedBorrows);
        }
        public IActionResult Create()
        {
            var vm = new BorrowViewModel
            {
                Books = GetBooks(),
                Members = GetMember()
            };
            return View(vm);
        }
        //[HttpPost]
        //public IActionResult Create(BorrowViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var MappedBorrow = _mapper.Map<BorrowViewModel,Borrow>(vm);
        //        int count = _borrow.Add(MappedBorrow);
        //        if(count > 0)
        //        {
        //            MappedBorrow.Book.AvailableCopies--;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    LoadDropDowns(vm);
        //    return View(vm);
        //}
        [HttpPost]
        public IActionResult Create(BorrowViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                LoadDropDowns(vm);
                return View(vm);
            }

            var book = _book.GetById(vm.BookId);

            if (book == null)
                return NotFound();

            if (book.AvailableCopies <= 0)
            {
                ModelState.AddModelError("", "This book is not available.");

                LoadDropDowns(vm);
                return View(vm);
            }

            var borrow = _mapper.Map<Borrow>(vm);

            int count = _borrow.Add(borrow);

            if (count > 0)
            {
                book.AvailableCopies--;

                _book.Update(book);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id )
        {
            if (id is null)
                return BadRequest();
            var borrow = _borrow.GetbyId(id.Value);
            if(borrow is null)
                return NotFound();
            var MappedBorrow = _mapper.Map<Borrow, BorrowViewModel>(borrow);
            return View(MappedBorrow);
        }
        [HttpPost]
        public IActionResult Edit(BorrowViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var MappedBorrow = _mapper.Map<BorrowViewModel, Borrow>(vm);
                var book = _book.GetById(MappedBorrow.BookId);
                MappedBorrow.Status = BorrowStatus.Returned;
                MappedBorrow.ReturnDate = DateTime.Now;
                book.AvailableCopies++;
                _book.Update(book);
                _borrow.Update(MappedBorrow);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
