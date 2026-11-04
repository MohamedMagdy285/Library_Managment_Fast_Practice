using AutoMapper;
using Library_Managment.DAL.Models;
using Library_Managment.PL.ViewModels;

namespace Library_Managment.PL.MappingProfiles
{
    public class BorrowProfile :Profile
    {
        public BorrowProfile()
        {
            CreateMap<BorrowViewModel,Borrow>().ReverseMap();
        }
    }
}
