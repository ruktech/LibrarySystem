using LibrarySystem.Entities.Books;

namespace LibrarySystem.Mvc.Models.Borrowings
{
    public class BorrowingsViewModel
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        // ==== Relations === //

        public int MemberId { get; set; }
        public string MemberFullName { get; set; }


        public int BookId { get; set; }
        public string BookTitle { get; set; }
    }
}
