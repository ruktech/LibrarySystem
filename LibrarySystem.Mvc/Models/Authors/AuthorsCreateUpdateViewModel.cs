using LibrarySystem.Entities.Books;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Mvc.Models.Authors
{
    public class AuthorsCreateUpdateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Bio { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [ValidateNever]
        public string FullName { get; set; }

    }
}
