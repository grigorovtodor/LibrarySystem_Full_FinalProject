using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class BookBusinessToBookDataProfile : Profile
    {
        public BookBusinessToBookDataProfile()
        {
            this.CreateMap<BookBusiness, Book>();
        }
    }
}
