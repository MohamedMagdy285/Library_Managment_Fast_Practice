using AutoMapper;
using Library_Managment.DAL.Models;
using Library_Managment.PL.ViewModels;

namespace Library_Managment.PL.MappingProfiles
{
    public class BookProfile :Profile
    {
        public BookProfile()
        {
            CreateMap<BookViewModel, Book>().ReverseMap();
        }
    }
}
