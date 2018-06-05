using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using System;

namespace LibrarySystemPro.WebClient.Models.Profiles
{
    public class RentedBookBusinessToRentedBookWebProfile : Profile
    {
        public RentedBookBusinessToRentedBookWebProfile()
        {
            this.CreateMap<RentedBookBusiness, RentedBook>();
        }
    }
}
