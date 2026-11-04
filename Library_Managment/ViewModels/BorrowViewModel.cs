using Library_Managment.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Managment.PL.ViewModels
{
    public class BorrowViewModel
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus Status { get; set; }
        //Member
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member? Member { get; set; }
        //Book
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        //
        public IEnumerable<SelectListItem> Books { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Members { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
