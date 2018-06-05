using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class RentedBookDataToRentedBookBusinessProfile : Profile
    {
        public RentedBookDataToRentedBookBusinessProfile()
        {
            this.CreateMap<RentedBook, RentedBookBusiness>();
        }
    }
}
