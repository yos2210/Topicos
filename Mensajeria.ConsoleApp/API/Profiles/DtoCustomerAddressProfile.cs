using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Netcore.Api.AdventureWorks.Profiles
{
    public class DtoCustomerAddressProfile : Profile
    {
        public DtoCustomerAddressProfile()
        {
            CreateMap<NorthWnd.Model.MyModels.CustomerAddress, DTOModels.DtoCustomerAddress>();
        }
    }
}
