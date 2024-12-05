using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarySystem.Mvc.Models.Borrowings
{
    public class BorrowingsCreateUpdateViewModel
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        // ==== Relations === //

        public int MemberId { get; set; }
        //public string MemberFullName { get; set; }


        public int BookId { get; set; }
        //public string BookTitle { get; set; }

        // ============ Lookups ========== //

        [ValidateNever]
        public SelectList MemberLookup { get; set; }

        [ValidateNever]
        public SelectList BookLookup { get; set; }
    }
}
