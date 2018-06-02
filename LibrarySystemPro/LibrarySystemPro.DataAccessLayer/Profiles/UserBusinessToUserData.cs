using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class UserBusinessToUserData : Profile
    {
        public UserBusinessToUserData()
        {
            this.CreateMap<UserBusiness, User>();
        }
    }
}
