using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Entities.Authors;
using LibrarySystem.Mvc.Data;
using AutoMapper;
using LibrarySystem.Mvc.Models.Authors;

namespace LibrarySystem.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        #region Data and Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            var authorsVMs = _mapper.Map<List<AuthorsViewModel>>(authors);
            return View(authorsVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorVM = _mapper.Map<AuthorsDetailsViewModel>(author);

            return View(authorVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorsCreateUpdateViewModel authorCreateVM)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<Author>(authorCreateVM);

                _context.Add(author);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(authorCreateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorUpdateVM = _mapper.Map<AuthorsCreateUpdateViewModel>(author);

            return View(authorUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorsCreateUpdateViewModel authorUpdateVM)
        {
            if (id != authorUpdateVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                // Get Author Entity from Database
                var author = await _context.Authors.FindAsync(id);

                if (author == null) 
                {
                    return NotFound();
                }

                // Patch (copy) The AuthorUpdateVM into the author entity
                _mapper.Map(authorUpdateVM, author);

                // Update the author in the _conetxt object and save to database
                _context.Update(author);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(authorUpdateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods
        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
        #endregion
    }
}
