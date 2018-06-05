using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class RentedBookWebToRentedBookBusiness : Profile
    {
        public RentedBookWebToRentedBookBusiness()
        {
            this.CreateMap<RentedBook, RentedBookBusiness>();
        }
    }
}
