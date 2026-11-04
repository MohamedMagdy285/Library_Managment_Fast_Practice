using Library_Managment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        IEnumerable<Member> GetAllWithBorrows();
        Member GetbyId(int id);
        Member GetByIdWithBorrows(int id);
        int Add(Member member);
        int Update(Member member);
        int Delete(Member member);
    }
}
