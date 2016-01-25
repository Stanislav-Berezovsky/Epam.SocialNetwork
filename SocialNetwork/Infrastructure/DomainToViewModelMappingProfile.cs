using AutoMapper;
using Entity;
using SocialNetwork.ViewsModels;

namespace SocialNetwork.Infrastructure
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile() : base("DomainToViewModelMappings")
        {

        }

        protected override void Configure()
        {
            CreateMap<User, ProfileViewModel>();
        }
    }
}