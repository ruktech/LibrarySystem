using LibrarySystem.Entities.Books;
using LibrarySystem.Entities.Members;

namespace LibrarySystem.Entities.Borrowings
{
    /*    
        *    Fields: id, borrow_date, return_date.
        *    Relationship: Belongs to Book (One-to-Many).
        *                  Belongs to Library Member (One-to-Many).
    */
    public class Borrowing
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        // ==== Relations === //

        public int MemberId { get; set; }
        public Member Member { get; set; }


        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
