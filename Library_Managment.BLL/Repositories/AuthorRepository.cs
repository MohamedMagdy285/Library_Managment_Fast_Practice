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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Library_ManagmentDbContext _context;

        public AuthorRepository(Library_ManagmentDbContext context)
        {
            _context = context;
        }     

        public int Add(Author Author)
        {
            _context.Add(Author);
            return _context.SaveChanges();
        }

        public int Delete(Author Author)
        {
            _context.Remove(Author);
            return _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        => _context.Authors.ToList();

        public Author GetById(int id)
        => _context.Authors.Find(id);

        public IQueryable<Author> SearchByName(string name)
        => _context.Authors.Where(n => n.Name.ToLower().Contains(name.ToLower()));   


        public int Update(Author Author)
        {
            _context.Update(Author);
            return _context.SaveChanges();
        }
    }
}
