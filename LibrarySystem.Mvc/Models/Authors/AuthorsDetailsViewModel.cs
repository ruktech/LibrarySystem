using LibrarySystem.Entities.Books;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Mvc.Models.Authors
{
    public class AuthorsDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }
        public string Bio { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        // === Relations === //
        public List<Book> Books { get; set; } = [];

    }
}
