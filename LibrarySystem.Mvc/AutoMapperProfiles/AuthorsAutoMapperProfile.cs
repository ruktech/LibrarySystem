using AutoMapper;
using LibrarySystem.Entities.Authors;
using LibrarySystem.Mvc.Models.Authors;

namespace LibrarySystem.Mvc.AutoMapperProfiles
{
    public class AuthorsAutoMapperProfile : Profile
    {
        public AuthorsAutoMapperProfile()
        {
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorsDetailsViewModel>();
            CreateMap<Author, AuthorsCreateUpdateViewModel>().ReverseMap();
        }
    }
}
