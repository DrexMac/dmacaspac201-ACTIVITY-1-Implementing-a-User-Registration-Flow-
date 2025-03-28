using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dmacaspac201.Data.Models;

namespace dmacaspac201.Contracts.LoginInfo
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<dmacaspac201.Data.Models.LoginInfo, LoginInfoDto>();
            CreateMap<LoginInfoDto, dmacaspac201.Data.Models.LoginInfo>();
        }
    }
}
