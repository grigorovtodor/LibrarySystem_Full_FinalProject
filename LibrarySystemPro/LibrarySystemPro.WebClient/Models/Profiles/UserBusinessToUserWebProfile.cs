using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class UserBusinessToUserWebProfile : Profile
    {
        public UserBusinessToUserWebProfile()
        {
            this.CreateMap<UserBusiness, User>();
        }
    }
}
