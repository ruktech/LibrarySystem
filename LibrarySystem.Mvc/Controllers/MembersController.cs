using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Entities.Members;
using LibrarySystem.Mvc.Data;
using AutoMapper;
using LibrarySystem.Mvc.Models.Members;

namespace LibrarySystem.Mvc.Controllers
{
    public class MembersController : Controller
    {
        #region Data and Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MembersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var memebers = await _context.Members.ToListAsync();
            var membersVMs = _mapper.Map<List<MembersViewModel>>(memebers);
            return View(membersVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            var memeberVM = _mapper.Map<MembersDetailsViewModel>(member);

            return View(memeberVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembersCreateUpdateViewModel memberCreateVM)
        {
            if (ModelState.IsValid)
            {
                var member = _mapper.Map<Member>(memberCreateVM);

                _context.Add(member);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(memberCreateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }
            var memberUpdateVM = _mapper.Map<MembersCreateUpdateViewModel>(member);

            return View(memberUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MembersCreateUpdateViewModel memberUpdateVM)
        {
            if (id != memberUpdateVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                // Get Member Entity from Database
                var member = await _context.Members.FindAsync(id);

                // Nullabilty Check
                if (member == null)
                {
                    return NotFound();
                }

                // Patch (copy) The MemberUpdateVM into the member entity
                _mapper.Map(memberUpdateVM, member);

                // Update the author in the _conetxt object and save to database
                _context.Update(member);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(memberUpdateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods
        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
        #endregion
    }
}
