using Library_Managment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public interface IBorrowRepository
    {
        IEnumerable<Borrow> GetAll();
        IEnumerable<Borrow> GetAllWithMemberAndBook();
        Borrow GetbyId(int id);
        int Add(Borrow borrow);
        int Update(Borrow borrow);
        int Delete(Borrow borrow);
    }
}
