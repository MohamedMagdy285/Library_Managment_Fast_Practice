using Library_Managment.DAL.Context;
using Library_Managment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Library_ManagmentDbContext _context;

        public CategoryRepository(Library_ManagmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
            => _context.Categories.ToList();

        public Category GetbyId(int id)
            => _context.Categories.Find(id);

        public int Add(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public int Update(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChanges();
        }

        public int Delete(Category category)
        {
            _context.Categories.Remove(category);
            return _context.SaveChanges();
        }
    }
}
