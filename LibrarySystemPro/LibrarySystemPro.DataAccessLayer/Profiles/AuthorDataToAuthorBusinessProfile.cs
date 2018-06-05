using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class AuthorDataToAuthorBusinessProfile : Profile
    {
        public AuthorDataToAuthorBusinessProfile()
        {
            this.CreateMap<Author, AuthorBusiness>();
        }
    }
}
