using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class BookBusinessToBookWebProfile : Profile
    {
        public BookBusinessToBookWebProfile()
        {
            this.CreateMap<BookBusiness, Book>();
        }
    }
}
