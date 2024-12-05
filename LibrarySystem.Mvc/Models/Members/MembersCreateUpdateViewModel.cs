using LibrarySystem.Utils.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Mvc.Models.Members
{
    public class MembersCreateUpdateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime MembershipDate { get; set; }

        [ValidateNever]
        public string FullName { get; set; }

    }
}
