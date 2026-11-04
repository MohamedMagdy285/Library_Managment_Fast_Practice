using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library_Managment.DAL.Models
{
  public class Book
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int TotalCopies{ get; set; }
        public int AvailableCopies{ get; set; }
        public string? ImageName { get; set; }
        public string? BookName { get; set; }
        //Author
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        //Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //Borrow
        public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    }
}
