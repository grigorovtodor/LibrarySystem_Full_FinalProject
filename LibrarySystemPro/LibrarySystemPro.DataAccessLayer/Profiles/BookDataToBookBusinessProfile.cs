using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class BookDataToBookBusinessProfile : Profile
    {
        public BookDataToBookBusinessProfile()
        {
            this.CreateMap<Book, BookBusiness>();
        }
    }
}
