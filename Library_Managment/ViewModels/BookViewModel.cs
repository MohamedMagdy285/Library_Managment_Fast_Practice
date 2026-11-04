using Library_Managment.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Managment.PL.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
        public string? BookName { get; set; }
        public IFormFile? Book { get; set; }
        //Author
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        //Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        //Dropdown


        public IEnumerable<SelectListItem> Authors { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
