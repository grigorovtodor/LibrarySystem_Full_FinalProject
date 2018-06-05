using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class UserBusinessToUserDataProfile : Profile
    {
        public UserBusinessToUserDataProfile()
        {
            this.CreateMap<UserBusiness, User>();
        }
    }
}
