using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.DAL.Models
{
    public class Borrow
    {
        public int Id{ get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate{ get; set; }
        public BorrowStatus Status { get; set; }
        //Member
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        //Book
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
