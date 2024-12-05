using LibrarySystem.Entities.Authors;
using LibrarySystem.Entities.Borrowings;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Books
{
    public class BooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
