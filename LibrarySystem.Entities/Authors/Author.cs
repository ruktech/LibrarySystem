using LibrarySystem.Entities.Books;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Entities.Authors
{
    /*    
        *    Fields: id, f_name, l_name, bio, birth_date.
        *    Relationship: Many-to-Many with Books.
    */
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }


        // === Relations === //
        public List<Book> Books { get; set; } = [];


        // === Properties === //

        [NotMapped]
        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
