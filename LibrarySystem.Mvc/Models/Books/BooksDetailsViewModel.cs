using LibrarySystem.Mvc.Models.Authors;

namespace LibrarySystem.Mvc.Models.Books
{
    public class BooksDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public int CopiesAvailable { get; set; }
        public List<AuthorsViewModel> Authors { get; set; } = [];
    }
}
