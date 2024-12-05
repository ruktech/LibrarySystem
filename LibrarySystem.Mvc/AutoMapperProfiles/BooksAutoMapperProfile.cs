using AutoMapper;
using LibrarySystem.Entities.Books;
using LibrarySystem.Mvc.Models.Books;

namespace LibrarySystem.Mvc.AutoMapperProfiles
{
    public class BooksAutoMapperProfile : Profile
    {
        public BooksAutoMapperProfile() 
        {
            CreateMap<Book, BooksViewModel>();
            CreateMap<Book, BooksDetailsViewModel>();
            CreateMap<Book, BooksCreateUpdateViewModel>().ReverseMap();
        }
    }
}
