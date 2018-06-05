using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class RentedBookBusinessToRentedBookDataProfile : Profile
    {
        public RentedBookBusinessToRentedBookDataProfile()
        {
            this.CreateMap<RentedBookBusiness, RentedBook>();
        }
    }
}
