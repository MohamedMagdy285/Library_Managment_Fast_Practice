using Library_Managment.DAL.Context;
using Library_Managment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly Library_ManagmentDbContext _context;

        public BookRepository(Library_ManagmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
            => _context.Books.ToList();

        public Book GetById(int id)
            => _context.Books.Find(id);

        public int Add(Book book)
        {
            _context.Books.Add(book);
            return _context.SaveChanges();
        }

        public int Update(Book book)
        {
            _context.Books.Update(book);
            return _context.SaveChanges();
        }

        public int Delete(Book book)
        {
            _context.Books.Remove(book);
            return _context.SaveChanges();
        }

        public Book GetBookWithAuthor(int id)
        {
            return _context.Books
                .Include(a => a.Author)
                .FirstOrDefault(a => a.Id ==id);
        }

        public Book GetBookWithCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBookWithAuthorAndCategory(int id)
        {
            return _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Book> GetBooksWithAuthorAndCategory()
        {
            return _context.Books
        .Include(b => b.Author)
        .Include(b => b.Category)
        .ToList();
        }

        public IQueryable<Book> SearchbyName(string name)
        => _context.Books.Include(b => b.Author)
        .Include(b => b.Category)
        .Where(a => a.Title.ToLower()
        .Contains(name.ToLower()));
    }
}
