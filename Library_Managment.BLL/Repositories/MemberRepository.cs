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
    public class MemberRepository : IMemberRepository
    {
        private readonly Library_ManagmentDbContext _context;

        public MemberRepository(Library_ManagmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAll()
            => _context.Members.ToList();

        public Member GetbyId(int id)
            => _context.Members.Find(id);

        public int Add(Member member)
        {
            _context.Members.Add(member);
            return _context.SaveChanges();
        }

        public int Update(Member member)
        {
            _context.Members.Update(member);
            return _context.SaveChanges();
        }

        public int Delete(Member member)
        {
            _context.Members.Remove(member);
            return _context.SaveChanges();
        }

        public Member GetByIdWithBorrows(int id)
            => _context.Members
                .Include(m => m.Borrows)
                .ThenInclude(b => b.Book)
                .FirstOrDefault(m => m.Id == id);

        public IEnumerable<Member> GetAllWithBorrows()
        => _context.Members
                .Include(m => m.Borrows)
                .ToList();
    }
}
