using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class AuthorBusinessToAuthorWebProfile : Profile
    {
        public AuthorBusinessToAuthorWebProfile()
        {
            this.CreateMap<AuthorBusiness, Author>();
        }
    }
}
