using AutoMapper;
using BlogMVC.Models;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            return serviceCollection;
        }
        public class AutoMapperMappingProfile : Profile
        {
            public AutoMapperMappingProfile()
            {
                CreateMap<Blog, BlogWithImage>()
                    .ReverseMap();
                CreateMap<User, UpdateProfileDto>()
                   .ReverseMap();
                CreateMap<WhatIDo, WhatIDoDto>()
                   .ReverseMap();


            }
        }
    }
}
//.ForMember(x => x.TransactionAcitivityTypeId, y => y.MapFrom(i => i.TransactionActivityType.TransactionActivityTypeId))
//.ForMember(x => x.CourtOfficeTypeId, y => y.MapFrom(i => i.CourtOfficeType.CourtOfficeTypeId))
