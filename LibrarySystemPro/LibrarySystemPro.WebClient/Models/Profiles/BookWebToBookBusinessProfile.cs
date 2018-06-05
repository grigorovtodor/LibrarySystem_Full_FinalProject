using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class BookWebToBookBusinessProfile : Profile
    {
        public BookWebToBookBusinessProfile()
        {
            this.CreateMap<Book, BookBusiness>();
        }
    }
}
