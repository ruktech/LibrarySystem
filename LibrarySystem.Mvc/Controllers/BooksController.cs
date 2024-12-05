using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Entities.Books;
using LibrarySystem.Mvc.Data;
using AutoMapper;
using LibrarySystem.Mvc.Models.Books;

namespace LibrarySystem.Mvc.Controllers
{
    public class BooksController : Controller
    {
        #region Data and Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            var booksVMs = _mapper.Map<List<BooksViewModel>>(books);
            return View(booksVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context
                                    .Books
                                    .Include(book => book.Authors)
                                    .Where(book => book.Id == id)
                                    .SingleOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            var bookDetailsVM = _mapper.Map<BooksDetailsViewModel>(book);

            return View(bookDetailsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var bookCreateVM = new BooksCreateUpdateViewModel();
            bookCreateVM.AuthorLookup = new MultiSelectList(_context.Authors, "Id", "FullName");
            return View(bookCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BooksCreateUpdateViewModel bookCreateVM)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(bookCreateVM);

                //Update the BookAuthor table
                await UpdateBookAuthors(book, bookCreateVM.AuthorIds);

                _context.Add(book);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            bookCreateVM.AuthorLookup = new MultiSelectList(_context.Authors, "Id", "FullName");
            return View(bookCreateVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context
                                    .Books
                                    .Include(book => book.Authors)
                                    .Where(book => book.Id == id)
                                    .SingleOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            var bookUpdateVM = _mapper.Map<BooksCreateUpdateViewModel>(book);
            bookUpdateVM.AuthorLookup = new MultiSelectList(_context.Authors, "Id", "FullName");

            return View(bookUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BooksCreateUpdateViewModel bookUpdateVM)
        {
            if (id != bookUpdateVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Get the book including its authors from the database
                var book = await _context
                                    .Books
                                    .Include(book => book.Authors)
                                    .Where(book => book.Id == id)
                                    .SingleOrDefaultAsync();

                // Nullability Check 
                if(book == null)
                {
                    return NotFound();
                }

                // Patch (copy) The bookUpdateVM inot the book entity
                _mapper.Map(bookUpdateVM, book);

                // Update BookAuthors Table
                await UpdateBookAuthors(book, bookUpdateVM.AuthorIds);

                // Add to context and save to DB
                _context.Update(book);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            bookUpdateVM.AuthorLookup = new MultiSelectList(_context.Authors, "Id", "FullName");
            return View(bookUpdateVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        private async Task UpdateBookAuthors(Book book, List<int> authorsIds)
        {
            // Clear Book Authors
            book.Authors.Clear();

            // Get Authors from Database
            var authors = await _context.Authors.Where(author => authorsIds.Contains(author.Id)).ToListAsync();

            // Add Authors to the Book
            book.Authors.AddRange(authors);
        }
        #endregion
    }
}
