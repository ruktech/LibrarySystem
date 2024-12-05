using AutoMapper;
using LibrarySystem.Entities.Members;
using LibrarySystem.Mvc.Models.Members;

namespace LibrarySystem.Mvc.AutoMapperProfiles
{
    public class MembersAutoMapperProfile : Profile
    {
        public MembersAutoMapperProfile() 
        {
            CreateMap<Member, MembersViewModel>();
            CreateMap<Member, MembersDetailsViewModel>();
            CreateMap<Member, MembersCreateUpdateViewModel>().ReverseMap();
        }
    }
}
