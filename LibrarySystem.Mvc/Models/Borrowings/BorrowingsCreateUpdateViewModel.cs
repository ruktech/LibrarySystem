using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Borrowings
{
    public class BorrowingsCreateUpdateViewModel
    {
        [Display(Name = "Borrowing Number")]
        public int Id { get; set; }

        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        // ==== Relations === //

        [Display(Name = "Member Name")]
        public int MemberId { get; set; }

        [Display(Name = "Book Name")]
        public int BookId { get; set; }

        // ============ Lookups ========== //

        [ValidateNever]
        public SelectList MemberLookup { get; set; }

        [ValidateNever]
        public SelectList BookLookup { get; set; }
    }
}
