using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class AuthorWebToAuthorBusinessProfile : Profile
    {
        public AuthorWebToAuthorBusinessProfile()
        {
            this.CreateMap<Author, AuthorBusiness>();
        }
    }
}
