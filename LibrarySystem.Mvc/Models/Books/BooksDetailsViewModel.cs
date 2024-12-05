using LibrarySystem.Mvc.Models.Authors;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Books
{
    public class BooksDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Avialable Copies")]
        public int CopiesAvailable { get; set; }
        public List<AuthorsViewModel> Authors { get; set; } = [];
    }
}
