using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Entities.Borrowings;
using LibrarySystem.Mvc.Data;
using AutoMapper;
using LibrarySystem.Mvc.Models.Borrowings;
using LibrarySystem.Entities.Books;

namespace LibrarySystem.Mvc.Controllers
{
    public class BorrowingsController : Controller
    {
        #region Data and Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BorrowingsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var borrowings = await _context.Borrowings.Include(b => b.Book).Include(b => b.Member).ToListAsync();
            var borrowingsVMs = _mapper.Map<List<BorrowingsViewModel>>(borrowings);

            return View(borrowingsVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings
                                                .Include(b => b.Book)
                                                .Include(b => b.Member)
                                                .Where(b => b.Id == id)
                                                .SingleOrDefaultAsync();
            if (borrowing == null)
            {
                return NotFound();
            }

            var borrowingDetailsVM = _mapper.Map<BorrowingsDetailsViewModel>(borrowing);

            return View(borrowingDetailsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var borrowingCreateVM = new BorrowingsCreateUpdateViewModel();
            
            borrowingCreateVM.BookLookup = new SelectList(_context.Books, "Id", "Title");
            borrowingCreateVM.MemberLookup = new SelectList(_context.Members, "Id", "FullName");

            return View(borrowingCreateVM);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowingsCreateUpdateViewModel borrowingCreateVM)
        {
            if (ModelState.IsValid)
            {
                var borrowing = _mapper.Map<Borrowing>(borrowingCreateVM);

                // Create a private method to check if copies are above 0 , then decrement by one
                if (!await UpdateBookCopies(borrowingCreateVM.BookId))
                {
                    ModelState.AddModelError("BookId", "The selected book is not available for borrowing.");
                    borrowingCreateVM.BookLookup = new SelectList(_context.Books, "Id", "Title");
                    borrowingCreateVM.MemberLookup = new SelectList(_context.Members, "Id", "FullName");
                    return View(borrowingCreateVM);
                }

                _context.Add(borrowing);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            borrowingCreateVM.BookLookup = new SelectList(_context.Books, "Id", "Title");
            borrowingCreateVM.MemberLookup = new SelectList(_context.Members, "Id", "FullName");

            return View(borrowingCreateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings.FindAsync(id);

            if (borrowing == null)
            {
                return NotFound();
            }

            var borrowingUpdateVM = _mapper.Map<BorrowingsCreateUpdateViewModel>(borrowing);

            borrowingUpdateVM.BookLookup = new SelectList(_context.Books, "Id", "Title");
            borrowingUpdateVM.MemberLookup = new SelectList(_context.Members, "Id", "FullName");

            return View(borrowingUpdateVM);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BorrowingsCreateUpdateViewModel borrowingUpdateVM)
        {
            if (id != borrowingUpdateVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                // Get the Borrowing Entity from Database
                var borrowing = await _context.Borrowings.FindAsync(id);

                // Nullablity Check
                if(borrowing == null)
                {
                    return NotFound();
                }

                // Patch (copy) the borrowingUpdateVM into the entity
                _mapper.Map(borrowingUpdateVM, borrowing);

                _context.Update(borrowing);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            borrowingUpdateVM.BookLookup = new SelectList(_context.Books, "Id", "Title");
            borrowingUpdateVM.MemberLookup = new SelectList(_context.Members, "Id", "FullName");

            return View(borrowingUpdateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowing = await _context.Borrowings.FindAsync(id);
            if (borrowing != null)
            {
                _context.Borrowings.Remove(borrowing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods
        private bool BorrowingExists(int id)
        {
            return _context.Borrowings.Any(e => e.Id == id);
        }

        private async Task<bool> UpdateBookCopies(int bookId)
        {
            // Find the book
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null || book.CopiesAvailable <= 0)
            {
                // Return false if the book doesn't exist or no copies are available
                return false;
            }

            // Decrement the copies available
            book.CopiesAvailable--;

            // Update the book in the context
            _context.Books.Update(book);

            return true;
        }


        #endregion
    }
}
