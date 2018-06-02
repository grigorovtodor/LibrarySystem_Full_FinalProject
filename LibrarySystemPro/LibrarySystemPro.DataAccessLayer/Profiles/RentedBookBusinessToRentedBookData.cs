using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemPro.DataAccessLayer.Profiles
{
    public class RentedBookBusinessToRentedBookData : Profile
    {
        public RentedBookBusinessToRentedBookData()
        {
            this.CreateMap<RentedBookBusiness, RentedBook>();
        }
    }
}
