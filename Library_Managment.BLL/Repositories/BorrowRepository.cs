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
    public class BorrowRepository : IBorrowRepository
    {
        private readonly Library_ManagmentDbContext _context;

        public BorrowRepository(Library_ManagmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Borrow> GetAll()
            => _context.Borrows.ToList();

        public Borrow GetbyId(int id)
            => _context.Borrows.Find(id);

        public int Add(Borrow borrow)
        {
            _context.Borrows.Add(borrow);
            return _context.SaveChanges();
        }

        public int Update(Borrow borrow)
        {
            _context.Borrows.Update(borrow);
            return _context.SaveChanges();
        }

        public int Delete(Borrow borrow)
        {
            _context.Borrows.Remove(borrow);
            return _context.SaveChanges();
        }

        public IEnumerable<Borrow> GetAllWithMemberAndBook()
            => _context.Borrows
                .Include(b => b.Member)
                .Include(b => b.Book);
    }
}
