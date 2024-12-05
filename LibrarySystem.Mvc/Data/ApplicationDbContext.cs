using LibrarySystem.Entities.Authors;
using LibrarySystem.Entities.Books;
using LibrarySystem.Entities.Borrowings;
using LibrarySystem.Entities.Members;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Member> Members { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
