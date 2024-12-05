using LibrarySystem.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Members
{
    public class MembersDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
