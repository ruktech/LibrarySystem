using LibrarySystem.Entities.Authors;
using LibrarySystem.Entities.Borrowings;
using LibrarySystem.Entities.Members;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Entities.Books
{
    /*    
        *    Fields: id, title, isbn, publish_date, copies_available.
        *    Relationships: Many-to-Many with Authors.
        *                   One-to-Many with Borrowings.
    */

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [MaxLength(16), Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Copies available must be non-negative.")]
        public int CopiesAvailable { get; set; }

        // ==== Relations === //
        public List<Author> Authors { get; set; } = [];
        public List<Borrowing> Borrowings { get; set; } = [];


    }
}
