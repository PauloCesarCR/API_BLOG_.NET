using Api_blog;
using AutoMapper;
using BlogApi.Models.Entities;
using System.Security.AccessControl;

namespace BlogApi.Mapping
{
    public class MapPostProfile : Profile
    {

        public MapPostProfile()
        {
            CreateMap<PostEntitie, Post>()
                   .ForMember(dest => dest.DescriptionImage, act => act.Condition(src => src.DescriptionImage != null));
        }
    }
}
