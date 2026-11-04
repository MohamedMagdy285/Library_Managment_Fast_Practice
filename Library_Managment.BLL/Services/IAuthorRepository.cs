using Library_Managment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.BLL.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        int Add(Author author);
        int Update(Author author);
        int Delete(Author author);
        IQueryable<Author> SearchByName(string name);
    }
}
