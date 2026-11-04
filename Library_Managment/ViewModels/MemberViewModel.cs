using Library_Managment.DAL.Models;

namespace Library_Managment.PL.ViewModels
{
    public class MemberViewModel
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
