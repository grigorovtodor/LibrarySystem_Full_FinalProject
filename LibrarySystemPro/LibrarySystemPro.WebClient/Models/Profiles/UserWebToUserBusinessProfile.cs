using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class UserWebToUserBusinessProfile : Profile
    {
        public UserWebToUserBusinessProfile()
        {
            this.CreateMap<User, UserBusiness>();
        }
    }
}
