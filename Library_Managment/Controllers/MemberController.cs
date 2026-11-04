using AutoMapper;
using Library_Managment.BLL.Services;
using Library_Managment.DAL.Models;
using Library_Managment.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_Managment.PL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _member;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository member,IMapper mapper)
        {
            _member = member;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var members = _member.GetAllWithBorrows();
            var MappedMembers = _mapper.Map<List<MemberViewModel>>(members);
            return View(MappedMembers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MemberViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var MappedMember = _mapper.Map<MemberViewModel,Member>(vm);
                _member.Add(MappedMember);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var member = _member.GetByIdWithBorrows(id.Value);
            if (member == null)
                return NotFound();
            var MappedMember = _mapper.Map<Member, MemberViewModel>(member);
            return View(MappedMember);
        }

    }
}
