using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Authors
{
    public class AuthorsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

    }
}
