using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.DAL.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public DateTime JoinDate { get; set; }
        public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
    }
}
