using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class AuthorBusinessToAuthorDataProfile : Profile
    {
        public AuthorBusinessToAuthorDataProfile()
        {
            this.CreateMap<AuthorBusiness, Author>();
        }
    }
}
