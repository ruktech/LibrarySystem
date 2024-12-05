using LibrarySystem.Utils.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Members
{
    public class MembersCreateUpdateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Member Since")]
        public DateTime MembershipDate { get; set; }

        [ValidateNever]
        public string FullName { get; set; }

    }
}
