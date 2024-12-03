using LibrarySystem.Entities.Borrowings;
using LibrarySystem.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Entities.Members
{
    public class Member
    {
        /*    
            *    Fields: id, name, email, birth_date, membership_date
            *    Relationship: One-to-Many with Borrowings.
        */

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate{ get; set; }

        [Required]
        public DateTime MembershipDate { get; set; }


        // === Relations === //
        public List<Borrowing> Borrowings { get; set; } = [];




        // === Properties === //

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }

        [NotMapped]
        public string MembershipDuration
        {
            get
            {
                var duration = DateTime.Now - MembershipDate;
                var years = (int)(duration.TotalDays / 365.25); // Approximate years
                var months = ((int)(duration.TotalDays % 365.25) / 30); // Approximate months
                var days = ((int)(duration.TotalDays % 365.25) % 30); // Remaining days

                return $"{years} years, {months} months, {days} days";
            }
        }

    }
}
