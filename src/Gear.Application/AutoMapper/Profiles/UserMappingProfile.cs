using AutoMapper;
using Gear.Application.ViewModels;
using Gear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gear.Application.AutoMapper.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<UserViewModel, UsersCredentials>().ReverseMap();  
        }
    }
}
