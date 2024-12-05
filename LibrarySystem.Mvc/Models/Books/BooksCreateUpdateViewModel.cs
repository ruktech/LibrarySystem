using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Books
{
    public class BooksCreateUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public int CopiesAvailable { get; set; }

        [Display(Name = "Authors")]
        public List<int> AuthorIds { get; set; } = [];

        // ==== Lookups ==== //

        [ValidateNever]
        public MultiSelectList AuthorLookup { get; set; }
    }
}
