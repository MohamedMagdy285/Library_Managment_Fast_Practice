using Library_Managment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetbyId(int id);
        int Add(Category category);
        int Update(Category category);
        int Delete(Category category);
    }
}
