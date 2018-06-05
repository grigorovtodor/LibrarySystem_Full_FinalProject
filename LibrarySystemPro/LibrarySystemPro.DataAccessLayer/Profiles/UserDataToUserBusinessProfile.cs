using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class UserDataToUserBusinessProfile : Profile
    {
        public UserDataToUserBusinessProfile()
        {
            this.CreateMap<User, UserBusiness>();
        }
    }
}
