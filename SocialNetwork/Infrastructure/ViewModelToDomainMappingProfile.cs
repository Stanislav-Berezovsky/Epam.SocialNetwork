using AutoMapper;
using Entity;
using SocialNetwork.ViewsModels;

namespace SocialNetwork.Infrastructure
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base("ViewModelToDomainMappings")
        {

        }

        protected override void Configure()
        {
            CreateMap<ProfileViewModel, User>();
        }
    }
}