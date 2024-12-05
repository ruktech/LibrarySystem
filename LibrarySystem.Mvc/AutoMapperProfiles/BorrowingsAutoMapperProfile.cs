using AutoMapper;
using LibrarySystem.Entities.Borrowings;
using LibrarySystem.Mvc.Models.Borrowings;

namespace LibrarySystem.Mvc.AutoMapperProfiles
{
    public class BorrowingsAutoMapperProfile : Profile
    {
        public BorrowingsAutoMapperProfile() 
        {
            CreateMap<Borrowing, BorrowingsViewModel>();
            CreateMap<Borrowing, BorrowingsDetailsViewModel>();
            CreateMap<Borrowing, BorrowingsCreateUpdateViewModel>().ReverseMap();
        }
    }
}
