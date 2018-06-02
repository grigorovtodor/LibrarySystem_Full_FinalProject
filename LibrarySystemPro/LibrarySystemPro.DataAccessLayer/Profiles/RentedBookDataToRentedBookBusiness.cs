using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class RentedBookDataToRentedBookBusiness : Profile
    {
        public RentedBookDataToRentedBookBusiness()
        {
            this.CreateMap<RentedBook, RentedBookBusiness>();
        }
    }
}
