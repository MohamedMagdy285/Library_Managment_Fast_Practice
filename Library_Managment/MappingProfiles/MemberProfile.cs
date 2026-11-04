using AutoMapper;
using Library_Managment.DAL.Models;
using Library_Managment.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment.PL.MappingProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<MemberViewModel, Member>().ReverseMap();
        }
    }
}
