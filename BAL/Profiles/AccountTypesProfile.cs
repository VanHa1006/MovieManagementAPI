using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BAL.DTOs.AccountTypes;
using DAL.Models;

namespace BAL.Profiles
{
    public class AccountTypesProfile : Profile
    {
        public AccountTypesProfile() 
        {
            CreateMap<Account, GetAccounts>().ReverseMap();
        }
    }
}
