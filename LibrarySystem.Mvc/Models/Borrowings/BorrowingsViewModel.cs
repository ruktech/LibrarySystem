using LibrarySystem.Entities.Books;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Borrowings
{
    public class BorrowingsViewModel
    {
        [Display(Name = "Borrowing Number")]
        public int Id { get; set; }

        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        // ==== Relations === //

        [Display(Name = "Member Name")]
        public string MemberFullName { get; set; }

        [Display(Name = "Book Name")]
        public string BookTitle { get; set; }
    }
}
