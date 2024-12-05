using LibrarySystem.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Members
{
    public class MembersViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        [Display(Name = "Membership Duration")]
        public string MembershipDuration { get; set; }
    }
}
