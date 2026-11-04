using Library_Managment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksWithAuthorAndCategory();
        Book GetById(int id);
        Book GetBookWithAuthor(int id);
        Book GetBookWithCategory(int id);
        Book GetBookWithAuthorAndCategory(int id);
        IQueryable<Book> SearchbyName(string name);
        int Add(Book book);
        int Update(Book book);
        int Delete(Book book);
    }
}
